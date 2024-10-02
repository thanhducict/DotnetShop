echo off

rem This script is for local development only.

set buildNumber=38
set configuration=Debug

dotnet build -c %configuration% src\DotnetShop.Admin.Core\DotnetShop.Admin.Core.csproj
dotnet build -c %configuration% src\DotnetShop.Admin.Ordering\DotnetShop.Admin.Ordering.csproj

if not exist src\DotnetShop.Admin.Ordering\ClientApp\node_modules\ (
  call npm install --prefix src\DotnetShop.Admin.Ordering\ClientApp
)
call npm run build:debug --prefix src\DotnetShop.Admin.Ordering\ClientApp

pwsh .\build\pack.ps1
