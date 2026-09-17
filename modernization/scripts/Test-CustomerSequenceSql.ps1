param(
    [Parameter(Mandatory=$true)][string]$Server,
    [Parameter(Mandatory=$true)][string]$Database,
    [string]$SqlCmd = 'sqlcmd'
)
$ErrorActionPreference = 'Stop'
$source = Get-Content -LiteralPath (Join-Path (Split-Path -Parent $PSScriptRoot) 'src/Essco.Infrastructure/Data/SqlServerCustomerChangeRepository.cs') -Raw
$match = [regex]::Match($source, 'const string SequenceSql\s*=\s*"""([\s\S]*?)""";')
if (-not $match.Success) { throw 'Sequence SQL not found.' }
$query = $match.Groups[1].Value.Replace('[dbo].[Empresa]', '#Empresa').Replace("'", "''")
if ($query -match '(?i)\bdbo\b') { throw 'Unexpected persistent table reference.' }
foreach ($case in @(
    @{ Name='Zero starts at one'; Rows='(0)'; Expected=1; Error=0 },
    @{ Name='Existing sequence increments'; Rows='(41)'; Expected=42; Error=0 },
    @{ Name='Last available sequence'; Rows='(2147483646)'; Expected=2147483647; Error=0 },
    @{ Name='Missing company'; Rows=''; Expected=0; Error=51001 },
    @{ Name='Multiple companies'; Rows='(1),(2)'; Expected=0; Error=51001 },
    @{ Name='Null sequence'; Rows='(NULL)'; Expected=0; Error=51003 },
    @{ Name='Negative sequence'; Rows='(-1)'; Expected=0; Error=51003 },
    @{ Name='Exhausted sequence'; Rows='(2147483647)'; Expected=0; Error=51003 }
)) {
    $seed = if ($case.Rows) { "INSERT #Empresa VALUES $($case.Rows);" } else { '' }
    $sql = @"
SET NOCOUNT ON;
CREATE TABLE #Empresa(Conse_Clientes int);
CREATE TABLE #Result(Value int);
$seed
DECLARE @Error int=0;
BEGIN TRANSACTION;
BEGIN TRY
 INSERT #Result EXEC sys.sp_executesql N'$query';
END TRY
BEGIN CATCH
 SET @Error=ERROR_NUMBER();
END CATCH;
IF @Error<>$($case.Error) RAISERROR('Unexpected sequence error',16,1);
IF @Error=0 AND (SELECT Value FROM #Result)<>$($case.Expected)
 RAISERROR('Incorrect sequence result',16,1);
ROLLBACK TRANSACTION;
"@
    & $SqlCmd -S $Server -d $Database -E -W -b -l 10 -t 30 -Q $sql
    if ($LASTEXITCODE -ne 0) { throw "Failed: $($case.Name)" }
    Write-Host "PASS: $($case.Name)"
}
Write-Host 'Only temporary tables were used; no customer or company records were modified.'
