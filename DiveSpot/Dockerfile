#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7033
EXPOSE 5133

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DiveSpot/DiveSpot.csproj", "DiveSpot/"]
RUN dotnet restore "DiveSpot/DiveSpot.csproj"
COPY . .
WORKDIR "/src/DiveSpot"
RUN dotnet build "DiveSpot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiveSpot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiveSpot.dll"]