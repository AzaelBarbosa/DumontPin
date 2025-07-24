# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar el archivo .csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del proyecto
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "DumontPin.dll"]# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copiar el archivo .csproj y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del proyecto
COPY . ./
RUN dotnet publish -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "DumontPin.dll"]
