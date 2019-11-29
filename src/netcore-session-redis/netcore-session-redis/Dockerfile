#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["netcore-session-redis/netcore-session-redis.csproj", "netcore-session-redis/"]
RUN dotnet restore "netcore-session-redis/netcore-session-redis.csproj"
COPY . .
WORKDIR "/src/netcore-session-redis"
RUN dotnet build "netcore-session-redis.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "netcore-session-redis.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "netcore-session-redis.dll"]