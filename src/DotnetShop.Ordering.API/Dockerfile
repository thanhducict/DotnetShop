FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["build/versions.props", "build/versions.props"]
COPY ["src/DotnetShop.Ordering.API/DotnetShop.Ordering.API.csproj", "src/DotnetShop.Ordering.API/"]
COPY ["src/DotnetShop.Ordering.Application/DotnetShop.Ordering.Application.csproj", "src/DotnetShop.Ordering.Application/"]
COPY ["src/DotnetShop.Ordering.Domain/DotnetShop.Ordering.Domain.csproj", "src/DotnetShop.Ordering.Domain/"]
COPY ["src/DotnetShop.Ordering.Infrastructure/DotnetShop.Ordering.Infrastructure.csproj", "src/DotnetShop.Ordering.Infrastructure/"]
COPY ["src/DotnetShop.Common/DotnetShop.Common.csproj", "src/DotnetShop.Common/"]
COPY ["src/DotnetShop.Common.Messaging/DotnetShop.Common.Messaging.csproj", "src/DotnetShop.Common.Messaging/"]
RUN dotnet restore "./src/DotnetShop.Ordering.API/DotnetShop.Ordering.API.csproj"
COPY . .
WORKDIR "/src/src/DotnetShop.Ordering.API"
RUN dotnet build "./DotnetShop.Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DotnetShop.Ordering.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetShop.Ordering.API.dll"]
