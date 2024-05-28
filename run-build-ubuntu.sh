#!/bin/bash

#  Build do frontend
cd frontend
docker build -t products-frontend-nextjs .

cd ../

#  Build do backend
cd ProductApi/ProductApi
docker build -t products-api .

cd ../..

# Rodando o Docker Compose
docker-compose up -d

