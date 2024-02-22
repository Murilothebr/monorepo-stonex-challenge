#!/bin/bash

# Build do frontend
cd frontend
docker build -t products-frontend-nextjs .
cd -

# Build do backend
cd frontend
docker build -t products-api .
cd -

# Rodando o Docker Compose
docker-compose up -d

# Aguardando a tecla Enter para fechar o bash
read -p "Pressione Enter para fechar o bash"
