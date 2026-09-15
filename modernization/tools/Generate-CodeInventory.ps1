param(
    [string]$RepositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot "../..")),
    [string]$OutputDirectory = (Join-Path $PSScriptRoot "../docs/inventory")
)

$ErrorActionPreference = "Stop"
$playRoot = Join-Path $RepositoryRoot "Play"

function Escape-Cell([string]$Value) {
    if ([string]::IsNullOrWhiteSpace($Value)) { return "—" }
    return (($Value -replace "\|", "\|") -replace "`r?`n", " ").Trim()
}

function Unique-Matches([string]$Text, [string]$Pattern, [int]$Group = 1) {
    [regex]::Matches($Text, $Pattern, [Text.RegularExpressions.RegexOptions]::IgnoreCase -bor [Text.RegularExpressions.RegexOptions]::Multiline) |
        ForEach-Object { $_.Groups[$Group].Value.Trim() } |
        Where-Object { $_ } |
        Sort-Object -Unique
}

function Get-Category([string]$Path, [string]$Name, [string]$Text) {
    if ($Path -match "\\DTO\\") { return "DTO" }
    if ($Path -match "\\LogicaNegocio\\") { return "Aplicación/reglas" }
    if ($Name -match "CONEXION|funcionesSQL|MYSQL" -or $Text -match "SqlConnection|MySqlConnection") { return "Datos" }
    if ($Name -match "SAP|Hacienda|Token|Firma|Correo|MAIL|FTP|Google|QR|XML") { return "Integración" }
    if ($Name -match "Crypto|Password|Seguridad") { return "Seguridad" }
    if ($Name -match "VariablesGlobales|Propiedades") { return "Estado global" }
    if ($Name -match "Planilla|Asientos") { return "Dominio/aplicación" }
    return "Utilidad o pendiente"
}

$roots = @("Class", "DTO", "LogicaNegocio") | ForEach-Object { Join-Path $playRoot $_ }
$files = $roots | Where-Object { Test-Path -LiteralPath $_ } |
    ForEach-Object { Get-ChildItem -LiteralPath $_ -Recurse -File -Filter "*.vb" } |
    Sort-Object FullName

$items = foreach ($file in $files) {
    $text = Get-Content -LiteralPath $file.FullName -Raw
    $types = Unique-Matches $text '^\s*(?:Public|Friend|Private|Protected)?\s*(?:Partial\s+)?(?:Class|Module|Structure|Interface|Enum)\s+([A-Za-z_][A-Za-z0-9_]*)'
    $methods = Unique-Matches $text '^\s*(?:Public|Friend|Private|Protected)?\s*(?:Shared\s+)?(?:Async\s+)?(?:Sub|Function)\s+([A-Za-z_][A-Za-z0-9_]*)'
    $properties = Unique-Matches $text '^\s*(?:Public|Friend|Private|Protected)?\s*(?:Shared\s+)?Property\s+([A-Za-z_][A-Za-z0-9_]*)'
    $imports = Unique-Matches $text '^\s*Imports\s+([^\r\n]+)'
    $sharedFields = Unique-Matches $text '^\s*(?:Public|Friend|Private|Protected)\s+Shared\s+([A-Za-z_][A-Za-z0-9_]*)'
    $publicModuleFields = Unique-Matches $text '^\s*Public\s+([A-Za-z_][A-Za-z0-9_]*)\s+As\s+'
    $category = Get-Category $file.FullName $file.BaseName $text
    $risks = @()
    if ($text -match "Option Strict Off") { $risks += "Tipado débil" }
    if ($text -match "On Error Resume Next") { $risks += "Errores ignorados" }
    if ($text -match "DoEvents") { $risks += "Bucle/UI acoplada" }
    if ($text -match "Thread\.Abort|Application\.Exit") { $risks += "Control de proceso" }
    if ($text -match "SqlConnection|MySqlConnection") { $risks += "Acceso directo a datos" }
    if ($text -match "SAPbobsCOM") { $risks += "COM/SAP" }
    if ($text -match "HttpWebRequest|WebClient") { $risks += "HTTP heredado" }

    [pscustomobject]@{
        File = [IO.Path]::GetRelativePath($RepositoryRoot, $file.FullName).Replace('\', '/')
        Name = $file.BaseName
        Category = $category
        Types = $types -join ", "
        Methods = $methods -join ", "
        Properties = $properties -join ", "
        Imports = $imports -join ", "
        Shared = (@($sharedFields) + @($publicModuleFields) | Sort-Object -Unique) -join ", "
        Risks = ($risks | Sort-Object -Unique) -join ", "
        LineCount = (Get-Content -LiteralPath $file.FullName).Count
    }
}

New-Item -ItemType Directory -Path $OutputDirectory -Force | Out-Null

$classes = [Text.StringBuilder]::new()
[void]$classes.AppendLine("# Inventario de clases, DTO y lógica")
[void]$classes.AppendLine()
[void]$classes.AppendLine("Generado por ``tools/Generate-CodeInventory.ps1`` mediante análisis estático.")
[void]$classes.AppendLine()
[void]$classes.AppendLine("- Archivos analizados: $($items.Count)")
[void]$classes.AppendLine("- Líneas aproximadas: $(($items | Measure-Object LineCount -Sum).Sum)")
[void]$classes.AppendLine()
[void]$classes.AppendLine("| Archivo | Clasificación inicial | Tipos | Métodos | Propiedades | Dependencias importadas | Riesgos |")
[void]$classes.AppendLine("|---|---|---|---|---|---|---|")
foreach ($item in $items) {
    $cells = @($item.File, $item.Category, $item.Types, $item.Methods, $item.Properties, $item.Imports, $item.Risks) |
        ForEach-Object { Escape-Cell $_ }
    [void]$classes.AppendLine("| $($cells -join ' | ') |")
}
[IO.File]::WriteAllText((Join-Path $OutputDirectory "CLASSES.md"), $classes.ToString(), [Text.UTF8Encoding]::new($false))

$rules = [Text.StringBuilder]::new()
[void]$rules.AppendLine("# Índice inicial de reglas de negocio")
[void]$rules.AppendLine()
[void]$rules.AppendLine("Este índice identifica candidatos; cada regla deberá confirmarse con su flujo, datos y pruebas antes de migrarse.")
[void]$rules.AppendLine()
[void]$rules.AppendLine("| Área | Archivo | Métodos candidatos | Destino propuesto |")
[void]$rules.AppendLine("|---|---|---|---|")
foreach ($item in $items | Where-Object { $_.Category -in @("Aplicación/reglas", "Dominio/aplicación", "Integración") -or $_.Methods }) {
    $destination = switch ($item.Category) {
        "Dominio/aplicación" { "Domain/Application" }
        "Aplicación/reglas" { "Application" }
        "Integración" { "Infrastructure o SapBridge" }
        default { "Pendiente de clasificación" }
    }
    $cells = @($item.Category, $item.File, $item.Methods, $destination) | ForEach-Object { Escape-Cell $_ }
    [void]$rules.AppendLine("| $($cells -join ' | ') |")
}
[IO.File]::WriteAllText((Join-Path $OutputDirectory "BUSINESS_RULES.md"), $rules.ToString(), [Text.UTF8Encoding]::new($false))

$globals = [Text.StringBuilder]::new()
[void]$globals.AppendLine("# Estado global identificado")
[void]$globals.AppendLine()
[void]$globals.AppendLine("Los miembros compartidos o públicos de módulos son candidatos a eliminar. En web, el estado de usuarios y empresas no puede mantenerse en variables globales de proceso.")
[void]$globals.AppendLine()
[void]$globals.AppendLine("| Archivo | Miembros detectados | Riesgo y tratamiento |")
[void]$globals.AppendLine("|---|---|---|")
foreach ($item in $items | Where-Object Shared) {
    $cells = @($item.File, $item.Shared, "Clasificar como configuración, servicio sin estado, contexto de solicitud o persistencia") |
        ForEach-Object { Escape-Cell $_ }
    [void]$globals.AppendLine("| $($cells -join ' | ') |")
}
[IO.File]::WriteAllText((Join-Path $OutputDirectory "GLOBAL_STATE.md"), $globals.ToString(), [Text.UTF8Encoding]::new($false))

Write-Output "Inventario generado: $($items.Count) archivos; $((($items | Measure-Object LineCount -Sum).Sum)) líneas aproximadas."
