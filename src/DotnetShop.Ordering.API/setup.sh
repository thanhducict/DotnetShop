dotnet ef migrations add InitialCreate -p ../DotnetShop.Ordering.Infrastructure/DotnetShop.Ordering.Infrastructure.csproj -s DotnetShop.Ordering.API.csproj
dotnet ef database update -p ../DotnetShop.Ordering.Infrastructure/DotnetShop.Ordering.Infrastructure.csproj -s DotnetShop.Ordering.API.csproj
