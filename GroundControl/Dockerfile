FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["GroundControl.csproj", ""]
RUN dotnet restore "./GroundControl.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "GroundControl.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GroundControl.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GroundControl.dll"]