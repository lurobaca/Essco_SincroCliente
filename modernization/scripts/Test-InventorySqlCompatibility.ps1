param(
    [Parameter(Mandatory=$true)][string]$Server,
    [Parameter(Mandatory=$true)][string]$Database,
    [string]$SqlCmd = 'sqlcmd'
)
$ErrorActionPreference = 'Stop'
$sourceDirectory = Join-Path (Split-Path -Parent $PSScriptRoot) 'src/Essco.Infrastructure/Data'
function Read-Query([string]$File, [string]$Literal = 'sql') {
    $source = Get-Content -LiteralPath (Join-Path $sourceDirectory $File) -Raw
    $match = [regex]::Match($source, ('const string ' + $Literal + '\s*=\s*"""([\s\S]*?)""";'))
    if (-not $match.Success) { throw "SQL literal not found: $File" }
    $query = $match.Groups[1].Value
    foreach ($table in @('Inv_Registro','Inv_ConActivo','Inv_Conteos','Inv_Inventario','Inv_Grupos','Inve_Conteo')) {
        $query = $query.Replace("dbo.$table", "#$table")
    }
    if ($query -match '(?i)\bdbo\.') { throw 'Unexpected persistent table reference.' }
    return $query.Replace("'", "''")
}
$recount = Read-Query 'SqlServerInventoryRecountRepository.cs'
$complete = Read-Query 'SqlServerInventoryCountCompletion.cs'
$cross = Read-Query 'SqlServerInventoryCrossingRepository.cs'
$consolidate = Read-Query 'SqlServerInventoryConsolidationRepository.cs'
$close = Read-Query 'SqlServerInventoryRepository.cs'
$copy = Read-Query 'SqlServerInventoryCreationRepository.cs' 'copy'
$fixture = @'
SET NOCOUNT ON;
CREATE TABLE #Inv_Registro(id int,Cerrado int,InvFinal float,ENTRADAS float,SALIDAS float,DIFERENCIAS float);
CREATE TABLE #Inv_ConActivo(IdInventario int,Grupo varchar(50),Conteo int,Finalizado int);
CREATE TABLE #Inv_Conteos(IdInventario int,Grupo varchar(50),NumConteo int,CodArticulo nvarchar(100),
 Descripcion nvarchar(100),Cuenta int,Reconteo int,CodProveedor varchar(100));
CREATE TABLE #Inv_Inventario(IdInventario int,Codigo nvarchar(100),CodProveedor varchar(100),
 Unificado int,CF int,Stock int,Costo float,DF float,DFM float,Cerrado int);
CREATE TABLE #Inv_Grupos(CodInventario int,idGrupo varchar(50),Responsable nvarchar(200),
 Acompanante nvarchar(200),CodProveedor varchar(100),NombreProveedor nvarchar(300));
CREATE TABLE #Selected(Code nvarchar(100) COLLATE DATABASE_DEFAULT NOT NULL);
CREATE TABLE #Result(Value int);
INSERT #Inv_Registro(id,Cerrado) VALUES(1,0);
INSERT #Inv_Inventario VALUES(1,N'A&''<>','P',0,0,10,2,0,0,0),(1,N'B','P',0,0,20,2,0,0,0);
INSERT #Inv_Conteos VALUES(1,'A',3,N'A&''<>','First',10,1,'P'),(1,'A',3,N'B','Second',20,1,'P');
INSERT #Inv_ConActivo VALUES(1,'A',3,1);
INSERT #Selected VALUES(N'A&''<>');
'@
function Run-Case([string]$Name,[string]$Body) {
    & $SqlCmd -S $Server -d $Database -E -b -W -l 10 -t 30 -Q ($fixture + $Body)
    if ($LASTEXITCODE -ne 0) { throw "Failed: $Name" }
    Write-Host "PASS: $Name"
}
$invokeRecount = "INSERT #Result EXEC sys.sp_executesql N'$recount',N'@Id int,@Group nvarchar(50),@Previous int',1,N'A',@Previous;"
Run-Case 'Successive recounts 4, 5 and 6 retain unselected quantities' @"
DECLARE @Previous int=3;
WHILE @Previous<6
BEGIN
 DELETE #Result;
 $invokeRecount
 IF (SELECT Value FROM #Result)<>1 RAISERROR('Recount rejected',16,1);
 IF NOT EXISTS(SELECT 1 FROM #Inv_Conteos WHERE NumConteo=@Previous+1 AND CodArticulo=N'B' AND Cuenta=20 AND Reconteo=1)
  RAISERROR('Unselected quantity lost',16,1);
 IF NOT EXISTS(SELECT 1 FROM #Inv_Conteos WHERE NumConteo=@Previous+1 AND CodArticulo=N'A&''<>' AND Cuenta=0 AND Reconteo=0)
  RAISERROR('Selected item not reset',16,1);
 UPDATE #Inv_Conteos SET Cuenta=10,Reconteo=1 WHERE NumConteo=@Previous+1 AND CodArticulo=N'A&''<>';
 UPDATE #Inv_ConActivo SET Finalizado=1 WHERE Conteo=@Previous+1;
 SET @Previous=@Previous+1;
END;
"@
foreach ($case in @(
 @{Name='Reject closed inventory';Change='UPDATE #Inv_Registro SET Cerrado=1;'},
 @{Name='Reject pending line';Change="UPDATE #Inv_Conteos SET Reconteo=0 WHERE CodArticulo=N'B';"},
 @{Name='Reject negative quantity';Change="UPDATE #Inv_Conteos SET Cuenta=-1 WHERE CodArticulo=N'B';"},
 @{Name='Reject unknown item';Change="INSERT #Selected VALUES(N'Unknown');"},
 @{Name='Reject duplicate selection';Change="INSERT #Selected VALUES(N'A&''<>');"},
 @{Name='Reject existing next count';Change="INSERT #Inv_ConActivo VALUES(1,'A',4,0);"}
)) {
 Run-Case $case.Name @"
$($case.Change)
DECLARE @Previous int=3;
$invokeRecount
IF (SELECT Value FROM #Result)<>0 RAISERROR('Invalid recount accepted',16,1);
IF (SELECT COUNT(*) FROM #Inv_Conteos)<>2 RAISERROR('Rejected recount changed lines',16,1);
"@
}
Run-Case 'Cross, complete, consolidate and close' @"
DELETE #Inv_Conteos;
DELETE #Inv_ConActivo;
INSERT #Inv_Conteos VALUES(1,'A',1,N'A&''<>','First',10,1,'P'),(1,'A',1,N'B','Second',20,1,'P'),
 (1,'A',2,N'A&''<>','First',10,1,'P'),(1,'A',2,N'B','Second',20,1,'P');
INSERT #Inv_ConActivo VALUES(1,'A',1,1),(1,'A',2,1);
INSERT #Inv_Grupos VALUES(1,'A','Tester','','P','Supplier');
INSERT #Result EXEC sys.sp_executesql N'$cross',N'@Id int,@Group nvarchar(50),@Threshold decimal(19,4)',1,N'A',0;
IF (SELECT Value FROM #Result)<>1 RAISERROR('Cross failed',16,1);
DELETE #Result;
INSERT #Result EXEC sys.sp_executesql N'$complete',N'@Id int,@Group nvarchar(50),@Number int',1,N'A',3;
IF (SELECT Value FROM #Result)<>1 RAISERROR('Count completion failed',16,1);
DELETE #Result;
INSERT #Result EXEC sys.sp_executesql N'$consolidate',
 N'@Id int,@Group nvarchar(50),@Supplier nvarchar(100),@Responsible nvarchar(200),@Companion nvarchar(200),@Threshold decimal(19,4)',
 1,N'AA',N'P',N'Tester',N'',0;
IF (SELECT Value FROM #Result)<>1 RAISERROR('Consolidation failed',16,1);
DELETE #Result;
INSERT #Result EXEC sys.sp_executesql N'$complete',N'@Id int,@Group nvarchar(50),@Number int',1,N'AA',4;
IF (SELECT Value FROM #Result)<>1 RAISERROR('Unified completion failed',16,1);
DELETE #Result;
INSERT #Result EXEC sys.sp_executesql N'$close',N'@Id int',1;
IF (SELECT Value FROM #Result)<>1 RAISERROR('Close failed',16,1);
IF NOT EXISTS(SELECT 1 FROM #Inv_Registro WHERE Cerrado=1 AND InvFinal=60 AND DIFERENCIAS=0)
 RAISERROR('Incorrect closing totals',16,1);
"@
Run-Case 'Copy numeric universe with textual sector' @"
ALTER TABLE #Inv_Inventario ADD Fecha date,Descripcion nvarchar(100),CodBarras nvarchar(100),
 Sector int,NameProveedor nvarchar(100),Monto float,Reconteo int,Pack int,NumLinea int;
CREATE TABLE #Inve_Conteo(ItemCode nvarchar(100),ItemName nvarchar(100),CodeBars nvarchar(100),
 Sector nvarchar(100),Price numeric(19,4),CodProveedor nvarchar(100),NameProveedor nvarchar(100),
 Stock_B1 numeric(19,4),Monto_B1 numeric(19,4),Empaque numeric(19,4));
INSERT #Inve_Conteo VALUES('NEW','New product',NULL,' 12 ',2,'P','Supplier',10,20,1);
EXEC sys.sp_executesql N'$copy',N'@Id int',2;
IF NOT EXISTS(SELECT 1 FROM #Inv_Inventario WHERE IdInventario=2 AND Codigo='NEW'
 AND Sector=12 AND Stock=10 AND Costo=2 AND Monto=20 AND Pack=1)
 RAISERROR('Universe copy failed',16,1);
"@
Write-Host 'All SQL fixture checks passed. Only connection-local temporary tables were modified.'
