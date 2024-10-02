$configuration = $Env:configuration

$versionSuffix = $Env:isProduction -eq 'true' ? '' : '-inte-' + $Env:buildNumber

[xml] $versionFile = Get-Content "./build/versions.props"
$adminCoreVersion = $versionFile.SelectSingleNode("Project/PropertyGroup/AdminCoreVersion").InnerText + $versionSuffix

dotnet pack --no-restore --no-build -c $configuration -o artifacts -p:Configuration=$configuration -p:AdminCoreVersion=$adminCoreVersion .\src\DotnetShop.Admin.Core\DotnetShop.Admin.Core.csproj

[xml] $versionFile = Get-Content "./Build/versions.props"
$adminOrderingVersion = $versionFile.SelectSingleNode("Project/PropertyGroup/AdminCoreVersion").InnerText + $versionSuffix

dotnet pack --no-restore --no-build -c $configuration -o artifacts -p:Configuration=$configuration -p:AdminOrderingVersion=$adminOrderingVersion -p:AdminCoreVersion=$adminCoreVersion src\DotnetShop.Admin.Ordering\DotnetShop.Admin.Ordering.csproj
