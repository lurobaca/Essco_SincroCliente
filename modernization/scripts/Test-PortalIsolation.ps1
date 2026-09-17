param(
 [Parameter(Mandatory=$true)][string]$Server,
 [Parameter(Mandatory=$true)][string]$Database,
 [string]$SqlCmd='sqlcmd'
)
$ErrorActionPreference='Stop'
$source=Get-Content -LiteralPath (Join-Path (Split-Path -Parent $PSScriptRoot) 'src/Essco.Portal/PortalStore.cs') -Raw
function Extract([string]$Method) {
 $pattern='public async Task<IReadOnlyList<[^>]+>> '+$Method+'[\s\S]*?new SqlCommand\("""([\s\S]*?)"""'
 $match=[regex]::Match($source,$pattern)
 if(-not $match.Success){throw "Query missing: $Method"}
 $sql=$match.Groups[1].Value
 foreach($table in @('Portal.Organizaciones','Portal.OrganizacionAplicaciones','Portal.Aplicaciones','Portal.Accesos','Identidad.Membresias','Identidad.Usuarios')){
  $sql=$sql.Replace($table,'#'+$table.Split('.')[1])
 }
 if($sql -match '(Portal|Identidad)\.') {throw 'Unexpected persistent reference'}
 return $sql.Replace("'","''")
}
$organizations=Extract 'Organizations'
$applications=Extract 'Applications'
$fixture=@'
SET NOCOUNT ON;
CREATE TABLE #Organizaciones(Id uniqueidentifier,Nombre nvarchar(200),Activa bit);
CREATE TABLE #Usuarios(Id uniqueidentifier,Activo bit);
CREATE TABLE #Membresias(OrganizacionId uniqueidentifier,UsuarioId uniqueidentifier,Rol varchar(20),Activa bit);
CREATE TABLE #OrganizacionAplicaciones(OrganizacionId uniqueidentifier,AplicacionCodigo varchar(50),Habilitada bit);
CREATE TABLE #Aplicaciones(Codigo varchar(50),Nombre nvarchar(100),Descripcion nvarchar(500),Activa bit);
CREATE TABLE #Accesos(OrganizacionId uniqueidentifier,UsuarioId uniqueidentifier,AplicacionCodigo varchar(50));
CREATE TABLE #OrgResult(Id uniqueidentifier,Nombre nvarchar(200),Rol varchar(20));
CREATE TABLE #AppResult(Nombre nvarchar(100),Descripcion nvarchar(500),Enabled bit);
DECLARE @User uniqueidentifier=NEWID(),@OtherUser uniqueidentifier=NEWID(),
 @Org uniqueidentifier=NEWID(),@OtherOrg uniqueidentifier=NEWID();
INSERT #Usuarios VALUES(@User,1),(@OtherUser,1);
INSERT #Organizaciones VALUES(@Org,'A',1),(@OtherOrg,'B',1);
INSERT #Membresias VALUES(@Org,@User,'Miembro',1),(@OtherOrg,@OtherUser,'Administrador',1);
INSERT #Aplicaciones VALUES('syncro-cliente','Syncro','ERP',1);
INSERT #OrganizacionAplicaciones VALUES(@Org,'syncro-cliente',1),(@OtherOrg,'syncro-cliente',1);
'@
foreach($case in @(
 @{Name='Only member organization visible';Setup='';Query="INSERT #OrgResult EXEC sys.sp_executesql N'$organizations',N'@User uniqueidentifier',@User;";Check="IF (SELECT COUNT(*) FROM #OrgResult)<>1 OR EXISTS(SELECT 1 FROM #OrgResult WHERE Id<>@Org) RAISERROR('Organization leak',16,1);"},
 @{Name='Other organization applications denied';Setup='';Query="INSERT #AppResult EXEC sys.sp_executesql N'$applications',N'@User uniqueidentifier,@Org uniqueidentifier',@User,@OtherOrg;";Check="IF EXISTS(SELECT 1 FROM #AppResult) RAISERROR('Cross organization leak',16,1);"},
 @{Name='Member requires explicit access';Setup='';Query="INSERT #AppResult EXEC sys.sp_executesql N'$applications',N'@User uniqueidentifier,@Org uniqueidentifier',@User,@Org;";Check="IF (SELECT COUNT(*) FROM #AppResult)<>1 OR EXISTS(SELECT 1 FROM #AppResult WHERE Enabled=1) RAISERROR('Unexpected grant',16,1);"},
 @{Name='Explicit membership access';Setup="INSERT #Accesos VALUES(@Org,@User,'syncro-cliente');";Query="INSERT #AppResult EXEC sys.sp_executesql N'$applications',N'@User uniqueidentifier,@Org uniqueidentifier',@User,@Org;";Check="IF NOT EXISTS(SELECT 1 FROM #AppResult WHERE Enabled=1) RAISERROR('Missing grant',16,1);"},
 @{Name='Disabled user excluded';Setup="UPDATE #Usuarios SET Activo=0 WHERE Id=@User;";Query="INSERT #OrgResult EXEC sys.sp_executesql N'$organizations',N'@User uniqueidentifier',@User;";Check="IF EXISTS(SELECT 1 FROM #OrgResult) RAISERROR('Disabled user visible',16,1);"},
 @{Name='Inactive membership excluded';Setup="UPDATE #Membresias SET Activa=0 WHERE UsuarioId=@User;";Query="INSERT #AppResult EXEC sys.sp_executesql N'$applications',N'@User uniqueidentifier,@Org uniqueidentifier',@User,@Org;";Check="IF EXISTS(SELECT 1 FROM #AppResult) RAISERROR('Inactive member visible',16,1);"}
)) {
 & $SqlCmd -S $Server -d $Database -E -W -b -l 10 -t 30 -Q ($fixture+$case.Setup+$case.Query+$case.Check)
 if($LASTEXITCODE -ne 0){throw "Failed: $($case.Name)"}
 Write-Host "PASS: $($case.Name)"
}
Write-Host 'Only temporary tables were used.'
