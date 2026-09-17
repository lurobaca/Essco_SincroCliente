$ErrorActionPreference='Stop'
$root=Split-Path -Parent $PSScriptRoot
$web=Get-Content -LiteralPath (Join-Path $root 'src/Essco.Web/wwwroot/css/essco-brand.css') -Raw
$portal=Get-Content -LiteralPath (Join-Path $root 'src/Essco.Portal/wwwroot/css/essco-brand.css') -Raw
if($web -cne $portal){throw 'Portal and ERP brand styles differ.'}
foreach($file in @('src/Essco.Web/Pages/Shared/_Layout.cshtml','src/Essco.Web/Pages/Shared/_AccountLayout.cshtml','src/Essco.Portal/Pages/Shared/_Layout.cshtml')){
 $content=Get-Content -LiteralPath (Join-Path $root $file) -Raw
 foreach($required in @('essco-brand.css','essco-name','Easy Software Solution Company','Un mundo con menos clic.')){
  if(-not $content.Contains($required)){throw "Missing brand element in $file : $required"}
 }
 if($content.Contains('brand-mark')){throw "Unexpected logo symbol in $file"}
}
Write-Host 'PASS: identical brand styles and three typographic layouts.'
