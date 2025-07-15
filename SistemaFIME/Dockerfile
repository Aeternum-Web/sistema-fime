# Usar la imagen base de .NET 9.0 SDK para build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar archivos del proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del código y compilar
COPY . ./
RUN dotnet publish -c Release -o out

# Usar la imagen runtime para la aplicación final
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Exponer el puerto
EXPOSE 8080

# Punto de entrada
ENTRYPOINT ["dotnet", "SistemaFIME.dll"]