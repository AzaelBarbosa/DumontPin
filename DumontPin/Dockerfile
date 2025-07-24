# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo del proyecto primero (ajustado a tu nombre)
COPY DumontPin.csproj ./

# Restaurar dependencias
RUN dotnet restore

# Copiar el resto del contenido
COPY . ./

# Publicar la aplicación
RUN dotnet publish -c Release -o /out

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /out ./

ENTRYPOINT ["dotnet", "DumontPin.dll"]
