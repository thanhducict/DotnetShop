$Configuration = $Env:configuration

$versionSuffix = $Env:isProduction -eq 'true' ? '' : '-inte-' + $Env:buildNumber

[xml] $versionFile = Get-Content "./Build/versions.props"
$adminCoreVersion = $versionFile.SelectSingleNode("Project/PropertyGroup/AdminCoreVersion").InnerText + $versionSuffix

dotnet pack --no-restore --no-build -c $Configuration -o artifacts -p:Configuration=$Configuration -p:Version=$adminCoreVersion DotnetShop.Admin.Core\DotnetShop.Admin.Core.csproj

[xml] $versionFile = Get-Content "./Build/versions.props"
$adminOrderingVersion = $versionFile.SelectSingleNode("Project/PropertyGroup/AdminCoreVersion").InnerText + $versionSuffix
dotnet pack --no-restore --no-build -c $Configuration -o artifacts -p:Configuration=$Configuration -p:Version=$adminOrderingVersion DotnetShop.Admin.Ordering\DotnetShop.Admin.Ordering.csproj
