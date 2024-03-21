FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StudiGO.Web/StudiGO.Web.csproj", "StudiGO.Web/"]
COPY ["StudiGO.Core/StudiGO.Core.csproj", "StudiGO.Core/"]
RUN dotnet restore "StudiGO.Web/StudiGO.Web.csproj"
COPY . .
WORKDIR "/src/StudiGO.Web"
RUN dotnet build "StudiGO.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "StudiGO.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudiGO.Web.dll"]