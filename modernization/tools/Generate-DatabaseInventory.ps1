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

function Get-Engine([string]$Text) {
    $engines = @()
    if ($Text -match "MySqlConnection|MySqlCommand|MySqlDataAdapter") { $engines += "MySQL" }
    if ($Text -match "SqlConnection|SqlCommand|SqlDataAdapter") { $engines += "SQL Server" }
    if ($Text -match "OdbcConnection|OdbcCommand|OdbcDataAdapter") { $engines += "ODBC" }
    if ($Text -match "SAPbobsCOM|Recordset") { $engines += "SAP/Recordset" }
    if (-not $engines) { $engines += "Indirecto/desconocido" }
    return ($engines | Sort-Object -Unique) -join ", "
}

$files = Get-ChildItem -LiteralPath $playRoot -Recurse -File -Filter "*.vb" |
    Where-Object { $_.FullName -notmatch "\\(obj|bin)\\" -and $_.Name -notlike "*.Designer.vb" } |
    Sort-Object FullName

$references = [Collections.Generic.List[object]]::new()
$fileSummaries = [Collections.Generic.List[object]]::new()

$operationPatterns = [ordered]@{
    SELECT = '\bSELECT\b'
    INSERT = '\bINSERT\s+INTO\b'
    UPDATE = '\bUPDATE\b'
    DELETE = '\bDELETE\s+FROM\b'
    EXECUTE = '\b(?:EXEC|EXECUTE|CommandType\.StoredProcedure)\b'
}
$tablePatterns = @(
    '(?i)\bFROM\s+[\[\]`"]?([A-Za-z_][A-Za-z0-9_\.$]*)',
    '(?i)\bJOIN\s+[\[\]`"]?([A-Za-z_][A-Za-z0-9_\.$]*)',
    '(?i)\bUPDATE\s+[\[\]`"]?([A-Za-z_][A-Za-z0-9_\.$]*)',
    '(?i)\bINSERT\s+INTO\s+[\[\]`"]?([A-Za-z_][A-Za-z0-9_\.$]*)',
    '(?i)\bDELETE\s+FROM\s+[\[\]`"]?([A-Za-z_][A-Za-z0-9_\.$]*)'
)

foreach ($file in $files) {
    $lines = Get-Content -LiteralPath $file.FullName
    $text = $lines -join "`n"
    if ($text -notmatch '(?i)SqlConnection|MySqlConnection|OdbcConnection|SqlCommand|MySqlCommand|Recordset|\bSELECT\b|\bINSERT\s+INTO\b|\bUPDATE\b|\bDELETE\s+FROM\b') {
        continue
    }

    $relative = [IO.Path]::GetRelativePath($RepositoryRoot, $file.FullName).Replace('\', '/')
    $engine = Get-Engine $text
    $fileTables = [Collections.Generic.HashSet[string]]::new([StringComparer]::OrdinalIgnoreCase)
    $operations = [Collections.Generic.HashSet[string]]::new([StringComparer]::OrdinalIgnoreCase)
    $dynamicCount = 0
    $parameterCount = 0
    $transactionCount = 0

    for ($index = 0; $index -lt $lines.Count; $index++) {
        $line = $lines[$index]
        foreach ($entry in $operationPatterns.GetEnumerator()) {
            if ($line -match $entry.Value) { [void]$operations.Add($entry.Key) }
        }
        foreach ($pattern in $tablePatterns) {
            $matches = [regex]::Matches($line, $pattern)
            foreach ($match in $matches) {
                $table = $match.Groups[1].Value.TrimEnd(']', '`', '"')
                if ($table -and $table -notmatch '^(SELECT|SET|WHERE)$') {
                    [void]$fileTables.Add($table)
                    $operation = ($operationPatterns.GetEnumerator() | Where-Object { $line -match $_.Value } | Select-Object -First 1).Key
                    if (-not $operation) { $operation = "REFERENCE" }
                    $references.Add([pscustomobject]@{
                        Table = $table
                        Operation = $operation
                        Engine = $engine
                        File = $relative
                        Line = $index + 1
                    })
                }
            }
        }
        if ($line -match '(?i)(SELECT|INSERT|UPDATE|DELETE).*(\&|String\.Format|\{[0-9]+\})' -or
            $line -match '(?i)(Sql|Query|CommandText)\s*=.*\&') { $dynamicCount++ }
        if ($line -match '(?i)\.Parameters\.(Add|AddWithValue)|@[A-Za-z_][A-Za-z0-9_]*') { $parameterCount++ }
        if ($line -match '(?i)BeginTransaction|Commit\(|Rollback\(') { $transactionCount++ }
    }

    $fileSummaries.Add([pscustomobject]@{
        File = $relative
        Engine = $engine
        Operations = ($operations | Sort-Object) -join ", "
        Tables = ($fileTables | Sort-Object) -join ", "
        Dynamic = $dynamicCount
        Parameters = $parameterCount
        Transactions = $transactionCount
    })
}

New-Item -ItemType Directory -Path $OutputDirectory -Force | Out-Null

$database = [Text.StringBuilder]::new()
[void]$database.AppendLine("# Inventario de acceso a datos")
[void]$database.AppendLine()
[void]$database.AppendLine("Generado por ``tools/Generate-DatabaseInventory.ps1``. Por seguridad no reproduce cadenas de conexión ni consultas completas.")
[void]$database.AppendLine()
[void]$database.AppendLine("- Archivos con acceso directo o SQL detectable: $($fileSummaries.Count)")
[void]$database.AppendLine("- Referencias de tabla detectadas: $($references.Count)")
[void]$database.AppendLine("- Tablas/objetos únicos detectados: $(($references.Table | Sort-Object -Unique).Count)")
[void]$database.AppendLine("- Líneas con indicios de SQL dinámico/concatenado: $(($fileSummaries | Measure-Object Dynamic -Sum).Sum)")
[void]$database.AppendLine("- Líneas con parámetros detectables: $(($fileSummaries | Measure-Object Parameters -Sum).Sum)")
[void]$database.AppendLine("- Operaciones transaccionales detectables: $(($fileSummaries | Measure-Object Transactions -Sum).Sum)")
[void]$database.AppendLine()
[void]$database.AppendLine("| Archivo | Motor detectable | Operaciones | Tablas/objetos | SQL dinámico | Parámetros | Transacciones |")
[void]$database.AppendLine("|---|---|---|---|---:|---:|---:|")
foreach ($item in $fileSummaries) {
    $cells = @($item.File, $item.Engine, $item.Operations, $item.Tables, $item.Dynamic, $item.Parameters, $item.Transactions) |
        ForEach-Object { Escape-Cell ([string]$_) }
    [void]$database.AppendLine("| $($cells -join ' | ') |")
}
[void]$database.AppendLine()
[void]$database.AppendLine("## Criterio de migración")
[void]$database.AppendLine()
[void]$database.AppendLine("Cada consulta se moverá a un adaptador de infraestructura, será parametrizada y tendrá timeout, cancelación y transacción explícitos cuando corresponda. Las consultas concatenadas se consideran riesgo hasta demostrar que no incorporan entrada externa.")
[IO.File]::WriteAllText((Join-Path $OutputDirectory "DATABASE.md"), $database.ToString(), [Text.UTF8Encoding]::new($false))

$queries = [Text.StringBuilder]::new()
[void]$queries.AppendLine("# Índice de tablas y operaciones SQL")
[void]$queries.AppendLine()
[void]$queries.AppendLine("Índice estático de ubicaciones. No contiene consultas completas ni datos sensibles.")
[void]$queries.AppendLine()
[void]$queries.AppendLine("| Tabla/objeto | Operación | Motor | Archivo | Línea |")
[void]$queries.AppendLine("|---|---|---|---|---:|")
foreach ($reference in $references | Sort-Object Table, File, Line -Unique) {
    $cells = @($reference.Table, $reference.Operation, $reference.Engine, $reference.File, $reference.Line) |
        ForEach-Object { Escape-Cell ([string]$_) }
    [void]$queries.AppendLine("| $($cells -join ' | ') |")
}
[IO.File]::WriteAllText((Join-Path $OutputDirectory "SQL_QUERIES.md"), $queries.ToString(), [Text.UTF8Encoding]::new($false))

Write-Output "Inventario generado: $($fileSummaries.Count) archivos, $($references.Count) referencias, $(($references.Table | Sort-Object -Unique).Count) objetos únicos."
