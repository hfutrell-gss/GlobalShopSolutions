FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

RUN dotnet nuget add source https://nexus.spectralleap.com/repository/nuget-public/ -n nexus

COPY ["Directory.Build.props", ""]

COPY . .

RUN dotnet restore "GlobalShopSolutions.Server/GlobalShopSolutions.Server.csproj"
COPY . .

WORKDIR "/src/GlobalShopSolutions.Server"

RUN dotnet build "GlobalShopSolutions.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GlobalShopSolutions.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GlobalShopSolutions.Server.dll"]
