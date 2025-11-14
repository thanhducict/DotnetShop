FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["build/common.props", "build/common.props"]
COPY ["build/versions.props", "build/versions.props"]
COPY ["src/DotnetShop.ShoppingCart.API/DotnetShop.ShoppingCart.API.csproj", "src/DotnetShop.ShoppingCart.API/"]
COPY ["src/DotnetShop.Common/DotnetShop.Common.csproj", "src/DotnetShop.Common/"]
COPY ["src/DotnetShop.Common.Messaging/DotnetShop.Common.Messaging.csproj", "src/DotnetShop.Common.Messaging/"]
RUN dotnet restore "./src/DotnetShop.ShoppingCart.API/DotnetShop.ShoppingCart.API.csproj"
COPY . .
WORKDIR "/src/src/DotnetShop.ShoppingCart.API"
RUN dotnet publish "./DotnetShop.ShoppingCart.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DotnetShop.ShoppingCart.API.dll"]
