FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EB.Sensors.Statistics/EB.Sensors.Statistics.csproj", "EB.Sensors.Statistics/"]
RUN dotnet restore "EB.Sensors.Statistics/EB.Sensors.Statistics.csproj"
COPY . .
WORKDIR "/src/EB.Sensors.Statistics"
RUN dotnet build "EB.Sensors.Statistics.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EB.Sensors.Statistics.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EB.Sensors.Statistics.dll"]
