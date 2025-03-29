FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["build/versions.props", "build/versions.props"]
COPY ["src/DotnetShop.Catalog.API/DotnetShop.Catalog.API.csproj", "src/DotnetShop.Catalog.API/"]
COPY ["src/DotnetShop.Common/DotnetShop.Common.csproj", "src/DotnetShop.Common/"]
RUN dotnet restore "./src/DotnetShop.Catalog.API/DotnetShop.Catalog.API.csproj"
COPY . .
WORKDIR "/src/src/DotnetShop.Catalog.API"
RUN dotnet publish "./DotnetShop.Catalog.API.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DotnetShop.Catalog.API.dll"]
