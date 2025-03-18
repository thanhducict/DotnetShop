FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["build/versions.props", "build/versions.props"]
COPY ["src/DotnetShop.ShoppingCart.API/DotnetShop.ShoppingCart.API.csproj", "src/DotnetShop.ShoppingCart.API/"]
COPY ["src/DotnetShop.Common/DotnetShop.Common.csproj", "src/DotnetShop.Common/"]
COPY ["src/DotnetShop.Common.Messaging/DotnetShop.Common.Messaging.csproj", "src/DotnetShop.Common.Messaging/"]
RUN dotnet restore "./src/DotnetShop.ShoppingCart.API/DotnetShop.ShoppingCart.API.csproj"
COPY . .
WORKDIR "/src/src/DotnetShop.ShoppingCart.API"
RUN dotnet build "./DotnetShop.ShoppingCart.API.csproj" -c $BUILD_CONFIGURATION -o /app/build
RUN ./setup.sh

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DotnetShop.ShoppingCart.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotnetShop.ShoppingCart.API.dll"]
