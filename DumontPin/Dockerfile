FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY DumontPin.csproj ./
WORKDIR /app/DumontPin
RUN dotnet restore

WORKDIR /app
COPY . .
WORKDIR /app/DumontPin
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "DumontPin.dll"]