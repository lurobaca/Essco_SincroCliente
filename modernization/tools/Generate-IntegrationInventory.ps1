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

$definitions = [ordered]@{
    "SAP Business One" = 'SAPbobsCOM|SAP_BUSSINES_ONE|Interop\.SAP'
    "Hacienda Costa Rica" = 'Hacienda|TokenHacienda|api\.hacienda|recepcion.*comprobante|RespuestaHacienda'
    "Firma electrónica/XAdES" = 'FirmaXades|Microsoft\.Xades|X509Certificate|\.p12|\.pfx'
    "Correo SMTP" = 'SmtpClient|MailMessage|Class_MAIL|SendMail|System\.Net\.Mail'
    "Microsoft Office/Excel" = 'Microsoft\.Office\.Interop|Excel\.Application|ExportarAExcell'
    "FTP" = 'FtpWebRequest|Class_FTP|ftp://'
    "HTTP/REST" = 'HttpClient|HttpWebRequest|WebClient|RestSharp'
    "Google" = 'GoogleControl|Google\.Apis|GoogleAuthorization'
    "QR/código de barras" = 'QrCode|QR_CODE|Barcode'
    "Crystal Reports" = 'CrystalDecisions|ReportDocument|CrystalReportViewer|\.rpt'
    "XML" = 'XmlDocument|XDocument|XmlSerializer|XML_Generator|Class_XML_Conexion'
    "Impresión" = 'PrintDocument|PrintDialog|PrinterSettings|\.PrintToPrinter'
    "Archivos locales" = 'File\.(Read|Write|Copy|Move|Delete)|StreamReader|StreamWriter'
}

$sourceFiles = Get-ChildItem -LiteralPath $playRoot -Recurse -File -Include "*.vb", "*.config", "*.xml" |
    Where-Object { $_.FullName -notmatch "\\(obj|bin)\\" }

$usages = [Collections.Generic.List[object]]::new()
foreach ($file in $sourceFiles) {
    $text = Get-Content -LiteralPath $file.FullName -Raw -ErrorAction SilentlyContinue
    if (-not $text) { continue }
    foreach ($definition in $definitions.GetEnumerator()) {
        $matches = [regex]::Matches($text, $definition.Value, [Text.RegularExpressions.RegexOptions]::IgnoreCase)
        if ($matches.Count -gt 0) {
            $usages.Add([pscustomobject]@{
                Integration = $definition.Key
                File = [IO.Path]::GetRelativePath($RepositoryRoot, $file.FullName).Replace('\', '/')
                Matches = $matches.Count
            })
        }
    }
}

$references = [Collections.Generic.List[object]]::new()
$projectFiles = Get-ChildItem -LiteralPath $RepositoryRoot -Recurse -File -Filter "*.vbproj" |
    Where-Object { $_.FullName -notmatch "\\(obj|bin)\\" }
foreach ($projectFile in $projectFiles) {
    [xml]$xml = Get-Content -LiteralPath $projectFile.FullName -Raw
    $manager = [Xml.XmlNamespaceManager]::new($xml.NameTable)
    $manager.AddNamespace("msb", "http://schemas.microsoft.com/developer/msbuild/2003")
    foreach ($reference in $xml.SelectNodes("//msb:Reference", $manager)) {
        $include = ($reference.Include -split ',')[0]
        $hintNode = $reference.SelectSingleNode("msb:HintPath", $manager)
        $hintKind = if (-not $hintNode) { "Sistema/GAC" }
            elseif ($hintNode.InnerText -match '^\.\.\\|^[A-Za-z]:\\') { "Ruta local o relativa" }
            else { "Incluida en proyecto" }
        $references.Add([pscustomobject]@{
            Project = [IO.Path]::GetRelativePath($RepositoryRoot, $projectFile.FullName).Replace('\', '/')
            Name = $include
            HintKind = $hintKind
            ModernRisk = if ($include -match 'Crystal|Interop|SAP|Shockwave|Gecko|Xades|Barcode') { "Alto: validar o sustituir" } else { "Revisar compatibilidad" }
        })
    }
}

New-Item -ItemType Directory -Path $OutputDirectory -Force | Out-Null

$integrations = [Text.StringBuilder]::new()
[void]$integrations.AppendLine("# Inventario de integraciones")
[void]$integrations.AppendLine()
[void]$integrations.AppendLine("Generado por ``tools/Generate-IntegrationInventory.ps1``. Los conteos representan coincidencias estáticas, no operaciones funcionales confirmadas.")
[void]$integrations.AppendLine()
[void]$integrations.AppendLine("| Integración | Archivos afectados | Coincidencias | Destino arquitectónico |")
[void]$integrations.AppendLine("|---|---:|---:|---|")
foreach ($group in $usages | Group-Object Integration | Sort-Object Name) {
    $destination = if ($group.Name -eq "SAP Business One" -or $group.Name -eq "Impresión") { "SapBridge.Worker o adaptador Windows" }
        elseif ($group.Name -eq "Crystal Reports") { "Sustituir por web/PDF o puente temporal" }
        else { "Infrastructure mediante interfaz de Application" }
    $cells = @($group.Name, $group.Count, ($group.Group | Measure-Object Matches -Sum).Sum, $destination) | ForEach-Object { Escape-Cell ([string]$_) }
    [void]$integrations.AppendLine("| $($cells -join ' | ') |")
}
[void]$integrations.AppendLine()
[void]$integrations.AppendLine("## Ubicaciones")
[void]$integrations.AppendLine()
[void]$integrations.AppendLine("| Integración | Archivo | Coincidencias |")
[void]$integrations.AppendLine("|---|---|---:|")
foreach ($usage in $usages | Sort-Object Integration, File) {
    $cells = @($usage.Integration, $usage.File, $usage.Matches) | ForEach-Object { Escape-Cell ([string]$_) }
    [void]$integrations.AppendLine("| $($cells -join ' | ') |")
}
[IO.File]::WriteAllText((Join-Path $OutputDirectory "INTEGRATIONS.md"), $integrations.ToString(), [Text.UTF8Encoding]::new($false))

$dependencies = [Text.StringBuilder]::new()
[void]$dependencies.AppendLine("# Dependencias heredadas")
[void]$dependencies.AppendLine()
[void]$dependencies.AppendLine("No se publican rutas completas de `HintPath`; solamente se indica si la referencia depende de una ubicación local.")
[void]$dependencies.AppendLine()
[void]$dependencies.AppendLine("| Proyecto | Ensamblado | Resolución original | Riesgo de modernización |")
[void]$dependencies.AppendLine("|---|---|---|---|")
foreach ($reference in $references | Sort-Object Project, Name -Unique) {
    $cells = @($reference.Project, $reference.Name, $reference.HintKind, $reference.ModernRisk) | ForEach-Object { Escape-Cell $_ }
    [void]$dependencies.AppendLine("| $($cells -join ' | ') |")
}
[void]$dependencies.AppendLine()
[void]$dependencies.AppendLine("Las referencias COM, GAC y rutas locales no se copiarán al servidor web. Se encapsularán, actualizarán o sustituirán según las pruebas de cada integración.")
[IO.File]::WriteAllText((Join-Path $OutputDirectory "DEPENDENCIES.md"), $dependencies.ToString(), [Text.UTF8Encoding]::new($false))

Write-Output "Inventario generado: $($usages.Count) ubicaciones de integración y $($references.Count) referencias de ensamblado."
