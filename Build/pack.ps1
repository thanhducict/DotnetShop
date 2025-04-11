$configuration = $Env:configuration

$versionSuffix = $Env:isProduction -eq 'true' ? '' : '-inte-' + $Env:buildNumber

[xml] $versionFile = Get-Content "./build/versions.props"
$adminCoreVersion = $versionFile.SelectSingleNode("Project/PropertyGroup/AdminCoreVersion").InnerText + $versionSuffix

dotnet pack --no-restore --no-build -c $configuration -o artifacts -p:Configuration=$configuration -p:AdminCoreVersion=$adminCoreVersion src\DotnetShop.Admin.Core\DotnetShop.Admin.Core.csproj

[xml] $versionFile = Get-Content "./build/versions.props"
$adminOrderingVersion = $versionFile.SelectSingleNode("Project/PropertyGroup/AdminOrderingVersion").InnerText + $versionSuffix

dotnet pack --no-restore --no-build -c $configuration -o artifacts -p:Configuration=$configuration -p:AdminOrderingVersion=$adminOrderingVersion -p:AdminCoreVersion=$adminCoreVersion src\DotnetShop.Admin.Ordering\DotnetShop.Admin.Ordering.csproj

[xml] $versionFile = Get-Content "./build/versions.props"
$adminDashboardVersion = $versionFile.SelectSingleNode("Project/PropertyGroup/AdminDashboardVersion").InnerText + $versionSuffix

dotnet pack --no-restore --no-build -c $configuration -o artifacts -p:Configuration=$configuration -p:AdminDashboardVersion=$adminDashboardVersion -p:AdminCoreVersion=$adminCoreVersion src\DotnetShop.Admin.Dashboard\DotnetShop.Admin.Dashboard.csproj
