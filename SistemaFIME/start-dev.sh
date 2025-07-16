#!/bin/bash

# Detener contenedores existentes si están corriendo
docker-compose -f docker-compose.dev.yml down

# Construir e iniciar en modo desarrollo
docker-compose -f docker-compose.dev.yml up --build
