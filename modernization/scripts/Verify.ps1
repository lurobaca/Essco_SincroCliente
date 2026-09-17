$ErrorActionPreference = 'Stop'
$solutionDirectory = Split-Path -Parent $PSScriptRoot
$previousPackages = $env:NUGET_PACKAGES
$previousCliHome = $env:DOTNET_CLI_HOME
Push-Location -LiteralPath $solutionDirectory
try {
    # Keep NuGet paths short even when the checkout has a long Windows path.
    $env:NUGET_PACKAGES = Join-Path ([System.IO.Path]::GetTempPath()) 'essco-nuget'
    $env:DOTNET_CLI_HOME = Join-Path $solutionDirectory '.dotnet-home'
    dotnet restore Essco.Modern.sln --force
    if ($LASTEXITCODE -ne 0) { throw 'Dependency restoration failed.' }
    dotnet build Essco.Modern.sln --no-restore
    if ($LASTEXITCODE -ne 0) { throw 'Solution build failed.' }
    dotnet test Essco.Modern.sln --no-build --no-restore
    if ($LASTEXITCODE -ne 0) { throw 'Tests failed.' }
}
finally {
    $env:NUGET_PACKAGES = $previousPackages
    $env:DOTNET_CLI_HOME = $previousCliHome
    Pop-Location
}
