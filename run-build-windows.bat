@echo off

REM Build do frontend
cd frontend
docker build -t products-frontend-nextjs .

cd ../

REM Build do backend
cd ProductApi/ProductApi
docker build -t products-api .

cd ../..

REM Rodando o Docker Compose
docker-compose up -d
