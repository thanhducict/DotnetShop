echo off

rem This script is for local development only.

set buildNumber=50
set configuration=Debug
set ROOTPATH=%cd%

if not exist src\DotnetShop.Admin.Ordering\ClientApp\node_modules (
  cd src\DotnetShop.Admin.Ordering\ClientApp
  call npm install
  cd %ROOTPATH%
)

if not exist src\DotnetShop.Admin.Dashboard\ClientApp\node_modules (
  cd src\DotnetShop.Admin.Dashboard\ClientApp
  call npm install
  cd %ROOTPATH%
)

call npm run build:debug --prefix src\DotnetShop.Admin.Ordering\ClientApp
call npm run build:debug --prefix src\DotnetShop.Admin.Dashboard\ClientApp

dotnet build -c %configuration% src\DotnetShop.Admin.Core\DotnetShop.Admin.Core.csproj
dotnet build -c %configuration% src\DotnetShop.Admin.Ordering\DotnetShop.Admin.Ordering.csproj
dotnet build -c %configuration% src\DotnetShop.Admin.Dashboard\DotnetShop.Admin.Dashboard.csproj

pwsh .\build\pack.ps1
