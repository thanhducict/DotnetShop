#!/bin/bash
dotnet tool install --global dotnet-ef
/root/.dotnet/tools/dotnet-ef migrations add InitialCreate -p ../DotnetShop.Ordering.Infrastructure/DotnetShop.Ordering.Infrastructure.csproj -s DotnetShop.Ordering.API.csproj
/root/.dotnet/tools/dotnet-ef database update -p ../DotnetShop.Ordering.Infrastructure/DotnetShop.Ordering.Infrastructure.csproj -s DotnetShop.Ordering.API.csproj
