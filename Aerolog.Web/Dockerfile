#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM node:14-alpine AS node_base
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
COPY --from=node_base . .

WORKDIR /src
COPY ["Aerolog.Web.csproj", "Aerolog.Web/"]
COPY ["../Aerolog.Accessors/Aerolog.Accessors.csproj", "Aerolog.Accessors/"]
COPY ["../Aerolog.Core/Aerolog.Core.csproj", "Aerolog.Core/"]
COPY ["../Aerolog.Utilities/Aerolog.Utilities.csproj", "Aerolog.Utilities/"]
COPY ["../Aerolog.Engines/Aerolog.Engines.csproj", "Aerolog.Engines/"]
COPY ["../Aerolog.GraphQL/Aerolog.GraphQL.csproj", "Aerolog.GraphQL/"]
RUN dotnet restore "Aerolog.Web.csproj"
COPY . .
WORKDIR "/src/Aerolog.Web"
RUN dotnet build "Aerolog.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aerolog.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aerolog.Web.dll"]