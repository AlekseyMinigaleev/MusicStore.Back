FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MusicStoreApi/MusicStoreApi.csproj", "MusicStoreApi/"]
COPY ["MusicStoreDB/MusicStoreDB.csproj", "MusicStoreDB/"]
RUN dotnet restore "./MusicStoreApi/MusicStoreApi.csproj"
COPY . .
WORKDIR "/src/MusicStoreApi"
RUN dotnet build "./MusicStoreApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MusicStoreApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Собираем образ с Nginx
FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish .
COPY nginx/default.conf etc/nginx/conf.d/default.conf

