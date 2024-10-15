echo off

rem This script is for local development only.

set buildNumber=38
set configuration=Debug
set ROOTPATH=%cd%

echo %ROOTPATH%

dotnet build -c %configuration% src\DotnetShop.Admin.Core\DotnetShop.Admin.Core.csproj
dotnet build -c %configuration% src\DotnetShop.Admin.Ordering\DotnetShop.Admin.Ordering.csproj

if not exist src\DotnetShop.Admin.Ordering\ClientApp\node_modules (
  cd src\DotnetShop.Admin.Ordering\ClientApp
  call npm install
  cd %ROOTPATH%
)

call npm run build:debug --prefix src\DotnetShop.Admin.Ordering\ClientApp

pwsh .\build\pack.ps1
