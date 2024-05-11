FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release
WORKDIR /src

RUN dotnet nuget add source https://nexus.spectralleap.com/repository/nuget-public/ -n nexus

COPY ["GlobalShopSolutions.Server/GlobalShopSolutions.Server.csproj", "GlobalShopSolutions.Server/"]
COPY ["GlobalShopSolutions.Server.Infrastructure/GlobalShopSolutions.Server.Infrastructure.csproj", "GlobalShopSolutions.Server.Infrastructure/"]
COPY ["FinanceAndAccounting.Installation/FinanceAndAccounting.Installation.csproj", "FinanceAndAccounting.Installation/"]
COPY ["AccountsReceivable.Endpoints/AccountsReceivable.Endpoints.csproj", "AccountsReceivable.Endpoints/"]
COPY ["AccountsReceivable.Application/AccountsReceivable.Application.csproj", "AccountsReceivable.Application/"]
COPY ["AccountsReceivable.Domain/AccountsReceivable.Domain.csproj", "AccountsReceivable.Domain/"]
COPY ["Modeling.Domain/Modeling.Domain.csproj", "Modeling.Domain/"]
COPY ["Modeling.Application/Modeling.Application.csproj", "Modeling.Application/"]
COPY ["Modeling.Endpoints/Modeling.Endpoints.csproj", "Modeling.Endpoints/"]
COPY ["AccountsReceivable.Infrastructure/AccountsReceivable.Infrastructure.csproj", "AccountsReceivable.Infrastructure/"]
COPY ["Modeling.Infrastructure/Modeling.Infrastructure.csproj", "Modeling.Infrastructure/"]
COPY ["Modeling.Areas.Installation/Modeling.Areas.Installation.csproj", "Modeling.Areas.Installation/"]
COPY ["GlobalShopSolutions.Server.Sdk/GlobalShopSolutions.Server.Sdk.csproj", "GlobalShopSolutions.Server.Sdk/"]
COPY ["Tests.Infrastructure.InMemory/Tests.Infrastructure.InMemory.csproj", "Tests.Infrastructure.InMemory/"]
COPY ["Directory.Build.props", ""]

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
