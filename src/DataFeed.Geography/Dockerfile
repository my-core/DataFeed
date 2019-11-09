FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["DataFeed.Geography/DataFeed.Geography.csproj", "./"]
RUN dotnet restore "DataFeed.Geography.csproj"
WORKDIR "/src/DataFeed.Geography"
COPY . .

RUN dotnet build "DataFeed.Geography/DataFeed.Geography.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataFeed.Geography/DataFeed.Geography.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataFeed.Geography.dll"]