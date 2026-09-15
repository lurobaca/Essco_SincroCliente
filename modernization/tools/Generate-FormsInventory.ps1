param(
    [string]$RepositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot "../..")),
    [string]$OutputPath = (Join-Path $PSScriptRoot "../docs/inventory/FORMS.md")
)

$ErrorActionPreference = "Stop"
$playRoot = Join-Path $RepositoryRoot "Play"

if (-not (Test-Path -LiteralPath $playRoot)) {
    throw "No se encontró el directorio original Play en: $playRoot"
}

function Escape-MarkdownCell([string]$Value) {
    if ([string]::IsNullOrWhiteSpace($Value)) { return "—" }
    return ($Value -replace "\|", "\|") -replace "`r?`n", " "
}

function Get-Matches([string]$Text, [string]$Pattern, [int]$Group = 1) {
    return [regex]::Matches($Text, $Pattern, [Text.RegularExpressions.RegexOptions]::IgnoreCase) |
        ForEach-Object { $_.Groups[$Group].Value } |
        Where-Object { -not [string]::IsNullOrWhiteSpace($_) } |
        Sort-Object -Unique
}

$designerFiles = Get-ChildItem -LiteralPath $playRoot -Recurse -File -Filter "*.Designer.vb" |
    Where-Object { $_.FullName -notmatch "\\(obj|bin)\\" } |
    Sort-Object FullName

$rows = foreach ($designerFile in $designerFiles) {
    $basePath = $designerFile.FullName.Substring(0, $designerFile.FullName.Length - ".Designer.vb".Length)
    $codePath = "$basePath.vb"
    $designerText = Get-Content -LiteralPath $designerFile.FullName -Raw
    $codeText = if (Test-Path -LiteralPath $codePath) { Get-Content -LiteralPath $codePath -Raw } else { "" }
    $combinedText = "$designerText`n$codeText"

    $className = [IO.Path]::GetFileName($basePath)
    $inherits = (Get-Matches $designerText "Inherits\s+Global\.System\.Windows\.Forms\.([A-Za-z0-9_\.]+)" | Select-Object -First 1)
    if (-not $inherits) { $inherits = "Form" }

    $controlMatches = [regex]::Matches(
        $designerText,
        "Friend\s+WithEvents\s+[A-Za-z0-9_]+\s+As\s+(?:Global\.)?([A-Za-z0-9_\.]+)",
        [Text.RegularExpressions.RegexOptions]::IgnoreCase)
    $controlTypes = $controlMatches |
        ForEach-Object { ($_.Groups[1].Value -split '\.')[-1] } |
        Group-Object |
        Sort-Object @{ Expression = "Count"; Descending = $true }, Name |
        ForEach-Object { "$($_.Name) ($($_.Count))" }

    $events = Get-Matches $codeText "Handles\s+([^\r\n]+)" |
        ForEach-Object { $_ -split ',' } |
        ForEach-Object { $_.Trim() } |
        Sort-Object -Unique

    $tables = @()
    $tablePatterns = @(
        '\bFROM\s+[\[\]`"]?([A-Za-z0-9_\.]+)',
        '\bJOIN\s+[\[\]`"]?([A-Za-z0-9_\.]+)',
        '\bUPDATE\s+[\[\]`"]?([A-Za-z0-9_\.]+)',
        '\bINSERT\s+INTO\s+[\[\]`"]?([A-Za-z0-9_\.]+)',
        '\bDELETE\s+FROM\s+[\[\]`"]?([A-Za-z0-9_\.]+)'
    )
    foreach ($pattern in $tablePatterns) { $tables += Get-Matches $codeText $pattern }
    $tables = $tables | Sort-Object -Unique

    $reports = Get-Matches $combinedText "([A-Za-z0-9_\- ]+\.rpt)"
    $sap = if ($combinedText -match "SAPbobsCOM|SAP_BUSSINES_ONE|oCompany|Company\.GetBusinessObject") { "Sí" } else { "No identificado" }
    $sql = if ($tables.Count -gt 0 -or $combinedText -match "SqlConnection|MySqlConnection|Class_funcionesSQL|Class_Funciones_MYSQL") { "Sí" } else { "No identificado" }

    [pscustomobject]@{
        Form = $className
        RelativePath = [IO.Path]::GetRelativePath($RepositoryRoot, $codePath).Replace('\', '/')
        BaseType = $inherits
        Controls = if ($controlTypes) { $controlTypes -join ", " } else { "—" }
        Events = if ($events) { $events -join ", " } else { "—" }
        Tables = if ($tables) { $tables -join ", " } else { "—" }
        Reports = if ($reports) { $reports -join ", " } else { "—" }
        Sap = $sap
        Sql = $sql
        HasCode = Test-Path -LiteralPath $codePath
    }
}

$outputDirectory = Split-Path -Parent $OutputPath
New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null

$builder = [Text.StringBuilder]::new()
[void]$builder.AppendLine("# Inventario de formularios WinForms")
[void]$builder.AppendLine()
[void]$builder.AppendLine("Documento generado automáticamente por ``tools/Generate-FormsInventory.ps1``. No contiene credenciales ni valores de configuración.")
[void]$builder.AppendLine()
[void]$builder.AppendLine("- Formularios/diseñadores encontrados: $($rows.Count)")
[void]$builder.AppendLine("- Formularios con archivo de código asociado: $(($rows | Where-Object HasCode).Count)")
[void]$builder.AppendLine("- Formularios con referencia SAP detectable: $(($rows | Where-Object Sap -eq 'Sí').Count)")
[void]$builder.AppendLine("- Formularios con acceso a datos detectable: $(($rows | Where-Object Sql -eq 'Sí').Count)")
[void]$builder.AppendLine()
[void]$builder.AppendLine("> Este inventario usa análisis estático. Las referencias indirectas mediante clases compartidas deberán completarse durante el análisis de cada módulo.")
[void]$builder.AppendLine()
[void]$builder.AppendLine("| Formulario | Archivo | Base | Controles | Eventos manejados | Tablas detectadas | Reportes | SAP | Datos |")
[void]$builder.AppendLine("|---|---|---|---|---|---|---|---|---|")

foreach ($row in $rows) {
    $cells = @(
        $row.Form, $row.RelativePath, $row.BaseType, $row.Controls, $row.Events,
        $row.Tables, $row.Reports, $row.Sap, $row.Sql
    ) | ForEach-Object { Escape-MarkdownCell $_ }
    [void]$builder.AppendLine("| $($cells -join ' | ') |")
}

[void]$builder.AppendLine()
[void]$builder.AppendLine("## Próxima clasificación manual")
[void]$builder.AppendLine()
[void]$builder.AppendLine("Cada formulario será asociado con un módulo, caso de uso, permisos, rutas web y pruebas de paridad antes de migrar su comportamiento.")

[IO.File]::WriteAllText($OutputPath, $builder.ToString(), [Text.UTF8Encoding]::new($false))
Write-Output "Inventario generado: $OutputPath ($($rows.Count) formularios)"
