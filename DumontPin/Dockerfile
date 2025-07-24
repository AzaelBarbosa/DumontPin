# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiamos solo el .csproj desde la carpeta
COPY DumontPin/DumontPin.csproj DumontPin/
WORKDIR /app/DumontPin
RUN dotnet restore

# Copiamos todo el código
WORKDIR /app
COPY . .

# Publicamos la app desde la carpeta del proyecto
WORKDIR /app/DumontPin
RUN dotnet publish -c Release -o /out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /out ./

ENTRYPOINT ["dotnet", "DumontPin.dll"]
