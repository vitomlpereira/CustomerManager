#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/CustomerManager.Api/CustomerService.Api.csproj", "src/CustomerManager.Api/"]
COPY ["src/CustomerManager.Infrastructure/CustomerService.Infrastructure.csproj", "src/CustomerManager.Infrastructure/"]
COPY ["nuget/CommonLibrary/CommonLibrary.csproj", "nuget/CommonLibrary/"]
COPY ["src/CustomerManager.Core/CustomerService.Core.csproj", "src/CustomerManager.Core/"]
COPY ["src/CustomerManager.UseCases/CustomerService.UseCases.csproj", "src/CustomerManager.UseCases/"]
RUN dotnet restore "./src/CustomerManager.Api/CustomerService.Api.csproj"
COPY . .
WORKDIR "/src/src/CustomerManager.Api"
RUN dotnet build "./CustomerService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CustomerService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerService.Api.dll"]