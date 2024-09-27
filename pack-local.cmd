rem This file is for local development only.

set buildNumber=30
set configuration=Debug

dotnet build -c %configuration% DotnetShop.Admin.Core\ShopDotnetShop.Admin.Core.csproj
dotnet build -c %configuration% DotnetShop.Admin.Ordering\DotnetShop.Admin.Ordering.csproj

if not exist DotnetShop.Admin.Ordering\ClientApp\node_modules\ (
  call npm install --prefix DotnetShop.Admin.Ordering\ClientApp
)
call npm run build:debug --prefix DotnetShop.Admin.Ordering\ClientApp

pwsh .\Build\pack.ps1
