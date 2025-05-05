FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["build/common.props", "build/common.props"]
COPY ["build/versions.props", "build/versions.props"]
COPY ["src/DotnetShop.Discount.Grpc/DotnetShop.Discount.Grpc.csproj", "src/DotnetShop.Discount.Grpc/"]
RUN dotnet restore "./src/DotnetShop.Discount.Grpc/DotnetShop.Discount.Grpc.csproj"
COPY . .
WORKDIR "/src/src/DotnetShop.Discount.Grpc"
RUN dotnet publish "./DotnetShop.Discount.Grpc.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DotnetShop.Discount.Grpc.dll"]
