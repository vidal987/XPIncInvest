#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["XPIncInvest.API/XPIncInvest.API.csproj", "XPIncInvest.API/"]
COPY ["XPIncInvest.BuildingBlocks/XPIncInvest.BuildingBlocks.csproj", "XPIncInvest.BuildingBlocks/"]
COPY ["XPIncInvest.Domain/XPIncInvest.Domain.csproj", "XPIncInvest.Domain/"]
COPY ["XPIncInvest.Infrastructure/XPIncInvest.Infrastructure.csproj", "XPIncInvest.Infrastructure/"]
COPY ["XPIncInvest.Application/XPIncInvest.Application.csproj", "XPIncInvest.Application/"]


RUN dotnet restore "./XPIncInvest.API/XPIncInvest.API.csproj"
COPY . .
WORKDIR "/src/XPIncInvest.API"
RUN dotnet build "./XPIncInvest.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./XPIncInvest.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XPIncInvest.API.dll"]