#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/DesafioZeDelivery.Api/DesafioZeDelivery.Api.csproj", "src/DesafioZeDelivery.Api/"]
COPY ["src/DesafioZeDelivery.Core/DesafioZeDelivery.Core.csproj", "src/DesafioZeDelivery.Core/"]
RUN dotnet restore "src/DesafioZeDelivery.Api/DesafioZeDelivery.Api.csproj"
COPY . .
WORKDIR "/src/src/DesafioZeDelivery.Api"
RUN dotnet build "DesafioZeDelivery.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioZeDelivery.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioZeDelivery.Api.dll"]
