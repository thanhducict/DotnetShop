FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["build/common.props", "build/common.props"]
COPY ["build/versions.props", "build/versions.props"]
COPY ["src/DotnetShop.YarpApiGateway/DotnetShop.YarpApiGateway.csproj", "src/DotnetShop.YarpApiGateway/"]
RUN dotnet restore "./src/DotnetShop.YarpApiGateway/DotnetShop.YarpApiGateway.csproj"
COPY . .
WORKDIR "/src/src/DotnetShop.YarpApiGateway"
RUN dotnet build "./DotnetShop.YarpApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DotnetShop.YarpApiGateway.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetShop.YarpApiGateway.dll"]
