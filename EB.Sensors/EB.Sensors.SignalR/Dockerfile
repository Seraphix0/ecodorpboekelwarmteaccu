FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EB.Sensors.SignalR/EB.Sensors.SignalR.csproj", "EB.Sensors.SignalR/"]
RUN dotnet restore "EB.Sensors.SignalR/EB.Sensors.SignalR.csproj"
COPY . .
WORKDIR "/src/EB.Sensors.SignalR"
RUN dotnet build "EB.Sensors.SignalR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EB.Sensors.SignalR.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EB.Sensors.SignalR.dll"]
