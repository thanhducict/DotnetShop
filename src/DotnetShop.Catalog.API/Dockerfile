FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["build/versions.props", "build/versions.props"]
COPY ["src/DotnetShop.Catalog.API/DotnetShop.Catalog.API.csproj", "src/DotnetShop.Catalog.API/"]
COPY ["src/DotnetShop.Common/DotnetShop.Common.csproj", "src/DotnetShop.Common/"]
RUN dotnet restore "./src/DotnetShop.Catalog.API/DotnetShop.Catalog.API.csproj"
COPY . .
WORKDIR "/src/src/DotnetShop.Catalog.API"
RUN dotnet build "./DotnetShop.Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DotnetShop.Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetShop.Catalog.API.dll"]
