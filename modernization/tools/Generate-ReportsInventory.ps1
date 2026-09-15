param(
    [string]$RepositoryRoot = (Resolve-Path (Join-Path $PSScriptRoot "../..")),
    [string]$OutputPath = (Join-Path $PSScriptRoot "../docs/inventory/REPORTS.md")
)

$ErrorActionPreference = "Stop"

function Escape-Cell([string]$Value) {
    if ([string]::IsNullOrWhiteSpace($Value)) { return "—" }
    return (($Value -replace "\|", "\|") -replace "`r?`n", " ").Trim()
}

function Get-Strategy([string]$Name, [string]$References) {
    if ($Name -match "Factura|Devolucion|Deposito|Gasto|Liquidacion|Planilla") {
        return "PDF/Excel y vista imprimible; comparar totales y paginación"
    }
    if ($References -match "PrintToPrinter|Printer") {
        return "PDF/vista web más adaptador de impresión Windows si es indispensable"
    }
    return "Determinar parámetros y salida; preferir PDF o vista web"
}

$reportFiles = Get-ChildItem -LiteralPath $RepositoryRoot -Recurse -File -Filter "*.rpt" |
    Where-Object { $_.FullName -notmatch "\\(bin|obj|modernization)\\" } |
    Sort-Object FullName
$sourceFiles = Get-ChildItem -LiteralPath $RepositoryRoot -Recurse -File -Filter "*.vb" |
    Where-Object { $_.FullName -notmatch "\\(bin|obj|modernization)\\" }
$sourceCache = foreach ($source in $sourceFiles) {
    [pscustomobject]@{
        File = $source
        Text = Get-Content -LiteralPath $source.FullName -Raw -ErrorAction SilentlyContinue
    }
}
$datasets = Get-ChildItem -LiteralPath $RepositoryRoot -Recurse -File -Include "*.xsd", "*.xsc", "*.xss" |
    Where-Object { $_.FullName -notmatch "\\(bin|obj|modernization)\\" }

$rows = foreach ($report in $reportFiles) {
    $escapedName = [regex]::Escape($report.Name)
    $escapedBase = [regex]::Escape($report.BaseName)
    $references = $sourceCache | Where-Object { $_.Text -match $escapedName -or $_.Text -match "\b$escapedBase\b" }
    $referencePaths = $references | ForEach-Object {
        [IO.Path]::GetRelativePath($RepositoryRoot, $_.File.FullName).Replace('\', '/')
    } | Sort-Object -Unique

    $datasetMatches = $datasets | Where-Object {
        $_.BaseName -match [regex]::Escape(($report.BaseName -replace 'Reporte|Report|CR|2$', '')) -or
        $report.BaseName -match [regex]::Escape(($_.BaseName -replace '^DataSet_', ''))
    } | ForEach-Object {
        [IO.Path]::GetRelativePath($RepositoryRoot, $_.FullName).Replace('\', '/')
    } | Sort-Object -Unique

    $allReferenceText = ($references.Text -join "`n")
    $parameters = [regex]::Matches($allReferenceText, '(?i)(?:SetParameterValue|ParameterFields)\s*\(?\s*["'']([^"'']+)') |
        ForEach-Object { $_.Groups[1].Value } | Sort-Object -Unique
    $usage = @()
    if ($allReferenceText -match '(?i)PrintToPrinter|PrinterSettings') { $usage += "Impresión" }
    if ($allReferenceText -match '(?i)ExportToDisk|ExportFormatType|PortableDocFormat') { $usage += "Exportación" }
    if ($allReferenceText -match '(?i)ReportSource|CrystalReportViewer') { $usage += "Visualización" }

    [pscustomobject]@{
        Report = [IO.Path]::GetRelativePath($RepositoryRoot, $report.FullName).Replace('\', '/')
        SizeKb = [math]::Round($report.Length / 1KB, 1)
        References = $referencePaths -join ", "
        Datasets = $datasetMatches -join ", "
        Parameters = $parameters -join ", "
        Usage = ($usage | Sort-Object -Unique) -join ", "
        Strategy = Get-Strategy $report.BaseName $allReferenceText
    }
}

$outputDirectory = Split-Path -Parent $OutputPath
New-Item -ItemType Directory -Path $outputDirectory -Force | Out-Null
$builder = [Text.StringBuilder]::new()
[void]$builder.AppendLine("# Inventario de Crystal Reports")
[void]$builder.AppendLine()
[void]$builder.AppendLine("Generado por ``tools/Generate-ReportsInventory.ps1``. Los archivos `.rpt` son binarios y no se modifican; parámetros y usos se infieren desde VB.NET.")
[void]$builder.AppendLine()
[void]$builder.AppendLine("- Reportes encontrados: $($rows.Count)")
[void]$builder.AppendLine("- Reportes con invocación VB detectable: $(($rows | Where-Object References).Count)")
[void]$builder.AppendLine("- Reportes con impresión detectable: $(($rows | Where-Object Usage -match 'Impresión').Count)")
[void]$builder.AppendLine("- Reportes con exportación detectable: $(($rows | Where-Object Usage -match 'Exportación').Count)")
[void]$builder.AppendLine()
[void]$builder.AppendLine("| Reporte | KB | Invocado desde | Dataset candidato | Parámetros detectados | Uso | Estrategia inicial | Estado |")
[void]$builder.AppendLine("|---|---:|---|---|---|---|---|---|")
foreach ($row in $rows) {
    $cells = @($row.Report, $row.SizeKb, $row.References, $row.Datasets, $row.Parameters, $row.Usage, $row.Strategy, "Pendiente") |
        ForEach-Object { Escape-Cell ([string]$_) }
    [void]$builder.AppendLine("| $($cells -join ' | ') |")
}
[void]$builder.AppendLine()
[void]$builder.AppendLine("## Criterio de verificación")
[void]$builder.AppendLine()
[void]$builder.AppendLine("Cada sustitución deberá comparar datos, filtros, parámetros, fórmulas, agrupación, totales, moneda, impuestos, saltos de página, exportación e impresión con una ejecución controlada del reporte original.")
[IO.File]::WriteAllText($OutputPath, $builder.ToString(), [Text.UTF8Encoding]::new($false))

Write-Output "Inventario generado: $($rows.Count) reportes; $(($rows | Where-Object References).Count) con uso detectable."
