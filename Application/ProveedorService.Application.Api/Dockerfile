#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Application/ProveedorService.Application.Api/ProveedorService.Application.Api.csproj", "Application/ProveedorService.Application.Api/"]
COPY ["Infrastructure/MongoDb/ProveedorService.Infrastructure.MongoDb/ProveedorService.Infrastructure.MongoDb.csproj", "Infrastructure/MongoDb/ProveedorService.Infrastructure.MongoDb/"]
COPY ["Domain/Proveedor.Domain.Entities/Proveedor.Domain.Entities.csproj", "Domain/Proveedor.Domain.Entities/"]
COPY ["Domain/ProveedorService.Domain.Core/ProveedorService.Domain.Core.csproj", "Domain/ProveedorService.Domain.Core/"]
COPY ["Domain/ProveedorService.Domain.Dto/ProveedorService.Domain.Dto.csproj", "Domain/ProveedorService.Domain.Dto/"]
COPY ["Domain/ProveedorService.Domain.Utility/ProveedorService.Domain.Utility.csproj", "Domain/ProveedorService.Domain.Utility/"]
RUN dotnet restore "Application/ProveedorService.Application.Api/ProveedorService.Application.Api.csproj"
COPY . .
WORKDIR "/src/Application/ProveedorService.Application.Api"
RUN dotnet build "ProveedorService.Application.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProveedorService.Application.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProveedorService.Application.Api.dll"]