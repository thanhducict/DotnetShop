FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["build/common.props", "build/common.props"]
COPY ["build/versions.props", "build/versions.props"]
COPY ["src/DotnetShop.Identity.API/DotnetShop.Identity.API.csproj", "src/DotnetShop.Identity.API/"]
RUN dotnet restore "./src/DotnetShop.Identity.API/DotnetShop.Identity.API.csproj"
COPY . .
WORKDIR "/src/src/DotnetShop.Identity.API"
RUN dotnet publish "./DotnetShop.Identity.API.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DotnetShop.Identity.API.dll"]
