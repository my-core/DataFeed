FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["DataFeed.Geography.FeedMonitor/DataFeed.Geography.FeedMonitor.csproj", "./"]
COPY ["DataFeed.Geography.Model/DataFeed.Geography.Model.csproj", "./"]
RUN dotnet restore "DataFeed.Geography.FeedMonitor.csproj"
WORKDIR "/src/DataFeed.Geography.FeedMonitor"
COPY . .

RUN dotnet build "DataFeed.Geography.FeedMonitor/DataFeed.Geography.FeedMonitor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataFeed.Geography.FeedMonitor/DataFeed.Geography.FeedMonitor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataFeed.Geography.FeedMonitor.dll"]
