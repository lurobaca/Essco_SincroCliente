using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Billing;
using Essco.Application.Configuration;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Billing;

/// <summary>
/// Presenta y autoriza las operaciones de estado de transmisión del servidor heredado.
/// </summary>
[Authorize(Policy = Permissions.Billing)]
public sealed class TransmissionStatusModel(
    ITransmissionStatusRepository repository,
    TransmissionDispatchService dispatch,
    IAuthorizationService authorization,
    AuditService audit,
    IOptions<EsscoOptions> options,
    ILogger<TransmissionStatusModel> logger) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Agent { get; set; }

    [BindProperty(SupportsGet = true)]
    public string FileType { get; set; } = "Todos";

    [BindProperty(SupportsGet = true)]
    public string Status { get; set; } = "ERROR";

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;

    public IReadOnlyList<TransmissionRow> Items { get; private set; } = [];
    public long TotalRows { get; private set; }
    public IReadOnlyList<string> FtpAlerts { get; private set; } = [];
    public string? ActiveAgent { get; private set; }
    public string? CurrentProcess { get; private set; }
    public bool? DownloadFromFtp { get; private set; }
    public bool? TodayBlocked { get; private set; }
    public bool CanManage { get; private set; }
    public bool DispatchConfigured => dispatch.IsConfigured;
    public bool CanDispatch => CanManage && DispatchConfigured;
    public string? ErrorMessage { get; private set; }

    [TempData]
    public string? Notice { get; set; }

    [TempData]
    public bool NoticeIsError { get; set; }

    /// <summary>
    /// Consulta la bitácora y las señales operativas aplicando filtros validados.
    /// </summary>
    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        CanManage = await CanManageAsync();
        if ((Agent is { Length: > 0 } && !IsValidAgent(Agent)) ||
            FileType is not ("Todos" or "Pedidos" or "Devoluciones" or "Pagos") ||
            Status is not ("Todos" or "ERROR" or "SUBIDO") ||
            PageNumber < 1 || PageNumber > 100000)
        {
            ErrorMessage = "Los filtros indicados no son válidos.";
            return;
        }

        try
        {
            TransmissionSnapshot snapshot = await repository.ReadAsync(
                Agent, FileType, Status, PageNumber, cancellationToken);
            Items = snapshot.Rows;
            TotalRows = snapshot.TotalRows;
            ActiveAgent = snapshot.ActiveAgent;
            CurrentProcess = snapshot.CurrentProcess;
            DownloadFromFtp = snapshot.DownloadFromFtp;
            TodayBlocked = snapshot.TodayBlocked;
            FtpAlerts = snapshot.FtpAlerts;
        }
        catch (SqlException)
        {
            ErrorMessage = "No fue posible consultar los estados de transmisión. Verifique la conexión y las tablas de Syncro Cliente.";
        }
        catch (InvalidOperationException)
        {
            ErrorMessage = "La conexión de Syncro Cliente no está configurada.";
        }
    }

    /// <summary>
    /// Actualiza las señales del proceso sin recargar las filas ni modificar datos.
    /// </summary>
    public async Task<IActionResult> OnGetSignalsAsync(CancellationToken cancellationToken)
    {
        try
        {
            TransmissionSignals signals = await repository.ReadSignalsAsync(cancellationToken);
            return new JsonResult(signals);
        }
        catch (SqlException)
        {
            return StatusCode(503);
        }
        catch (InvalidOperationException)
        {
            return StatusCode(503);
        }
    }

    /// <summary>
    /// Elimina los resultados de un estado únicamente para el agente indicado y confirmado.
    /// </summary>
    public async Task<IActionResult> OnPostClearAsync(
        string agent,
        string fileType,
        string status,
        string confirmation,
        CancellationToken cancellationToken)
    {
        if (!await CanManageAsync())
        {
            return Forbid();
        }

        if (!IsValidAgent(agent) ||
            fileType is not ("Todos" or "Pedidos" or "Devoluciones" or "Pagos") ||
            status is not ("ERROR" or "SUBIDO") ||
            confirmation != "LIMPIAR")
        {
            Notice = "Indique un agente, un estado y escriba LIMPIAR para confirmar.";
            NoticeIsError = true;
            return RedirectToPage();
        }

        try
        {
            int affected = await repository.ClearAsync(agent.Trim(), status, cancellationToken);
            Notice = $"Se limpiaron {affected} registros {status} del agente {agent.Trim()}.";
            NoticeIsError = false;
            await LogAsync("Transmission.Clear", $"{agent.Trim()}:{status}", cancellationToken);
        }
        catch (SqlException)
        {
            Notice = "No fue posible limpiar los estados. No se confirmó el cambio.";
            NoticeIsError = true;
        }
        catch (InvalidOperationException)
        {
            Notice = "La conexión de Syncro Cliente no está configurada.";
            NoticeIsError = true;
        }

        return RedirectToPage(new { Agent = agent.Trim(), FileType = fileType, Status = status });
    }

    /// <summary>
    /// Marca una sola transmisión en ERROR para que el proceso externo la reintente.
    /// </summary>
    public async Task<IActionResult> OnPostRetryAsync(
        string agent,
        string file,
        string consecutive,
        string date,
        CancellationToken cancellationToken)
    {
        if (!await CanManageAsync())
        {
            return Forbid();
        }

        if (!IsValidAgent(agent) ||
            string.IsNullOrWhiteSpace(file) || file.Length > 100 ||
            string.IsNullOrWhiteSpace(consecutive) || consecutive.Length > 100 ||
            string.IsNullOrWhiteSpace(date) || date.Length > 100)
        {
            Notice = "No se pudo identificar la transmisión que desea reintentar.";
            NoticeIsError = true;
            return RedirectToPage();
        }

        try
        {
            int affected = await repository.RetryAsync(
                agent.Trim(), file.Trim(), consecutive.Trim(), date.Trim(), cancellationToken);
            Notice = affected switch
            {
                1 => "Transmisión marcada para reintento. El procesamiento depende del servicio externo.",
                -1 => "Hay transmisiones duplicadas; no se marcó ninguna para evitar un reintento ambiguo.",
                _ => "La transmisión ya no está en ERROR o no existe."
            };
            NoticeIsError = affected != 1;
            if (affected == 1)
            {
                await LogAsync("Transmission.Retry", $"{agent.Trim()}:{consecutive.Trim()}", cancellationToken);
            }
        }
        catch (SqlException)
        {
            Notice = "No fue posible marcar la transmisión para reintento.";
            NoticeIsError = true;
        }
        catch (InvalidOperationException)
        {
            Notice = "La conexión de Syncro Cliente no está configurada.";
            NoticeIsError = true;
        }

        return RedirectToPage(new { Agent = agent.Trim(), Status = "ERROR" });
    }

    /// <summary>
    /// Cambia la bandera heredada de descarga FTP/local cuando su tabla está íntegra.
    /// </summary>
    public async Task<IActionResult> OnPostSourceAsync(bool downloadFromFtp, CancellationToken cancellationToken)
    {
        if (!await CanManageAsync())
        {
            return Forbid();
        }

        try
        {
            int affected = await repository.SetSourceAsync(downloadFromFtp, cancellationToken);
            Notice = affected == 1
                ? $"Origen de descarga configurado: {(downloadFromFtp ? "FTP" : "local")}."
                : "No se cambió el origen: la tabla de configuración no contiene exactamente una fila.";
            NoticeIsError = affected != 1;
            if (affected == 1)
            {
                await LogAsync("Transmission.Source", downloadFromFtp ? "FTP" : "Local", cancellationToken);
            }
        }
        catch (SqlException)
        {
            Notice = "No fue posible cambiar el origen de descarga.";
            NoticeIsError = true;
        }
        catch (InvalidOperationException)
        {
            Notice = "La conexión de Syncro Cliente no está configurada.";
            NoticeIsError = true;
        }

        return RedirectToPage();
    }

    /// <summary>
    /// Ejecuta los tres flujos de envío heredados solamente cuando el FTP fue habilitado.
    /// </summary>
    public async Task<IActionResult> OnPostDispatchAsync(
        string? agent,
        string mode,
        CancellationToken cancellationToken)
    {
        if (!await CanManageAsync())
        {
            return Forbid();
        }

        if (!dispatch.IsConfigured)
        {
            Notice = "El envío no está habilitado para este entorno.";
            NoticeIsError = true;
            return RedirectToPage();
        }

        if (mode is not ("reload" or "upload" or "all") ||
            (mode != "all" && !IsValidDispatchAgent(agent)))
        {
            Notice = "Indique un número de agente válido para esta operación.";
            NoticeIsError = true;
            return RedirectToPage();
        }

        try
        {
            if (mode == "all")
            {
                int completed = await dispatch.DispatchAllAsync(cancellationToken);
                Notice = $"Se enviaron señales para {completed} agentes. Syncro Server procesará cada solicitud.";
            }
            else
            {
                await dispatch.DispatchAgentAsync(
                    agent!.Trim(),
                    reload: mode == "reload",
                    cancellationToken);
                Notice = $"Se envió la señal del agente {agent.Trim()}. El procesamiento depende de Syncro Server.";
            }

            NoticeIsError = false;
            try
            {
                await LogAsync(
                    "Transmission.Dispatch",
                    mode == "all" ? "All" : agent!.Trim(),
                    cancellationToken);
            }
            catch (Exception auditException) when (auditException is not OperationCanceledException)
            {
                // El envío ya ocurrió: un fallo posterior de auditoría no debe sugerir que se repita.
                logger.LogError(auditException, "No se pudo auditar una transmisión completada");
            }
        }
        catch (ArgumentException)
        {
            Notice = "El agente indicado no existe o no está habilitado para transmitir.";
            NoticeIsError = true;
        }
        catch (InvalidOperationException exception)
        {
            logger.LogWarning(exception, "No se pudo iniciar la transmisión del modo {Mode}", mode);
            Notice = "No se pudo iniciar la transmisión. Revise la configuración y si hay otra operación en curso.";
            NoticeIsError = true;
        }
        catch (Exception exception) when (exception is not OperationCanceledException)
        {
            logger.LogError(exception, "Falló la transmisión del modo {Mode}", mode);
            Notice = "Falló la transmisión. Puede haber cambios parciales en SQL; revise la bitácora y Syncro Server antes de repetirla.";
            NoticeIsError = true;
        }

        return RedirectToPage(new { Agent = mode == "all" ? null : agent, Status = "Todos" });
    }

    /// <summary>
    /// Aplica en backend el permiso adicional para operaciones que cambian el proceso.
    /// </summary>
    private async Task<bool> CanManageAsync()
    {
        return (await authorization.AuthorizeAsync(User, Permissions.Administration)).Succeeded;
    }

    /// <summary>
    /// Audita las mutaciones sin registrar mensajes de SAP ni credenciales FTP.
    /// </summary>
    private ValueTask LogAsync(string operation, string key, CancellationToken cancellationToken)
    {
        int? userId = int.TryParse(
            User.FindFirstValue(ClaimTypes.NameIdentifier),
            NumberStyles.None,
            CultureInfo.InvariantCulture,
            out int parsed) ? parsed : null;

        return audit.WriteAsync(
            userId,
            User.Identity?.Name,
            options.Value.DefaultCompany,
            operation,
            "Transmission",
            key,
            "Succeeded",
            HttpContext.TraceIdentifier,
            HttpContext.Connection.RemoteIpAddress?.ToString(),
            cancellationToken);
    }

    /// <summary>
    /// Exige un identificador numérico y acotado para las escrituras por agente.
    /// </summary>
    private static bool IsValidAgent(string? agent)
    {
        return !string.IsNullOrWhiteSpace(agent) &&
            agent.Length <= 30 &&
            agent.All(char.IsDigit);
    }

    /// <summary>
    /// La cola heredada almacena hasta diez caracteres y Agentes.CodAgente es entero.
    /// </summary>
    private static bool IsValidDispatchAgent(string? agent)
    {
        return !string.IsNullOrWhiteSpace(agent) &&
            agent.Length <= 10 &&
            agent.All(char.IsDigit) &&
            int.TryParse(agent, NumberStyles.None, CultureInfo.InvariantCulture, out _);
    }
}
