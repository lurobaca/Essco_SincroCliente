param([uri]$BaseUri = 'https://localhost:7152')
$ErrorActionPreference = 'Stop'
Add-Type -AssemblyName System.Net.Http
$handler = New-Object System.Net.Http.HttpClientHandler
$handler.AllowAutoRedirect = $false
$client = New-Object System.Net.Http.HttpClient($handler)
try {
    foreach ($path in @('/css/site.css', '/lib/bootstrap/dist/css/bootstrap.min.css', '/Essco.Web.styles.css')) {
        $response = $client.GetAsync([uri]::new($BaseUri, $path)).GetAwaiter().GetResult()
        try {
            if ([int]$response.StatusCode -ne 200 -or $response.Content.Headers.ContentType.MediaType -ne 'text/css') {
                throw "Stylesheet unavailable anonymously: $path ($($response.StatusCode))"
            }
            Write-Output "PASS CSS: $path"
        } finally { $response.Dispose() }
    }
    $response = $client.GetAsync([uri]::new($BaseUri, '/Inventory')).GetAwaiter().GetResult()
    try {
        if ([int]$response.StatusCode -ne 302 -or $response.Headers.Location.AbsolutePath -ne '/Account/Login') {
            throw 'Inventory must redirect anonymous requests to login.'
        }
        Write-Output 'PASS: Inventory requires login.'
    } finally { $response.Dispose() }
} finally { $client.Dispose() }
