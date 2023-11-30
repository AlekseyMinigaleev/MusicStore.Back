# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . /src

RUN dir

RUN dotnet restore "./MusicStoreApi/MusicStoreApi.csproj" --disable-parallel
RUN dotnet restore "./MusicStoreDB/MusicStoreDB.csproj" --disable-parallel

RUN dotnet publish "./MusicStoreApi/MusicStoreApi.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/sdk:7.0

RUN apt-get update
RUN apt-get install -y nginx
COPY nginx/default.conf /etc/nginx/sites-enabled/default	

WORKDIR /appv
COPY --from=build /app ./

EXPOSE 5000:5000

ENTRYPOINT ["/bin/bash", "-c", "service nginx start && dotnet MusicStoreApi.dll", "--server.urls", "http://0.0.0.0:5000"]
# Serve stage