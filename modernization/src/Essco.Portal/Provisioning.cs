using System.Net.Mail;
using System.Text;
namespace Essco.Portal;
public static class Provisioning
{
    public static async Task RunAsync(PortalStore store)
    {
        if (Console.IsInputRedirected) throw new InvalidOperationException("Ejecute la inicialización en una terminal interactiva.");
        if (!store.Configured) throw new InvalidOperationException("Configure ConnectionStrings:PortalSqlServer.");
        Console.Write("Correo del administrador: "); var email = Console.ReadLine()?.Trim() ?? "";
        if (!MailAddress.TryCreate(email,out var parsed) || parsed.Address != email || email.Length>254) throw new InvalidOperationException("Correo inválido.");
        Console.Write("Nombre: "); var name = Console.ReadLine()?.Trim() ?? "";
        Console.Write("Nombre de la organización: "); var organization = Console.ReadLine()?.Trim() ?? "";
        if (name.Length is < 1 or > 200 || organization.Length is < 1 or > 200) throw new InvalidOperationException("Nombre u organización inválidos.");
        Console.Write("Contraseña nueva (no se mostrará): "); var password = Secret();
        Console.Write("Confirme la contraseña: "); var confirmation = Secret();
        if (password != confirmation || password.Length < 12 || !password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
            throw new InvalidOperationException("Las contraseñas deben coincidir y tener 12 caracteres, mayúscula, minúscula y número.");
        await store.Provision(email,name,organization,password);
        Console.WriteLine("Administrador inicial creado. No se habilitó el acceso al ERP.");
    }
    private static string Secret()
    {
        var result = new StringBuilder();
        while (true)
        {
            var key = Console.ReadKey(intercept:true);
            if(key.Key==ConsoleKey.Enter) { Console.WriteLine(); return result.ToString(); }
            if(key.Key==ConsoleKey.Backspace) { if(result.Length>0) result.Length--; }
            else if(!char.IsControl(key.KeyChar) && result.Length<256) result.Append(key.KeyChar);
        }
    }
}
