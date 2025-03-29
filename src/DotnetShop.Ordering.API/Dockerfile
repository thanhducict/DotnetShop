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

FROM build AS migrations
WORKDIR "/src/src/DotnetShop.Ordering.API"
RUN dotnet tool install --global dotnet-ef
RUN /root/.dotnet/tools/dotnet-ef migrations add InitialCreate -p ../DotnetShop.Ordering.Infrastructure/DotnetShop.Ordering.Infrastructure.csproj -s DotnetShop.Ordering.API.csproj
CMD ["/bin/bash", "-c", "/root/.dotnet/tools/dotnet-ef database update -p ../DotnetShop.Ordering.Infrastructure/DotnetShop.Ordering.Infrastructure.csproj -s DotnetShop.Ordering.API.csproj"]

FROM build AS published
WORKDIR "/src/src/DotnetShop.Ordering.API"
RUN dotnet publish "./DotnetShop.Ordering.API.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=published /app/publish .
ENTRYPOINT ["dotnet", "DotnetShop.Ordering.API.dll"]
