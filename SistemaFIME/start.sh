#!/bin/bash

echo "🚀 Iniciando SistemaFIME con Docker..."

# Detener contenedores existentes
echo "📦 Deteniendo contenedores existentes..."
docker-compose down

# Construir y levantar los servicios
echo "🔨 Construyendo y levantando servicios..."
docker-compose up --build -d

echo "✅ SistemaFIME está ejecutándose!"
echo "🌐 Aplicación web: http://localhost:8080"
echo "🗄️  Base de datos PostgreSQL: localhost:5432"
echo ""
echo "Para ver los logs: docker-compose logs -f"
echo "Para detener: docker-compose down"