@echo off

REM Build do frontend
REM cd frontend
REM docker build -t products-frontend-nextjs .

REM Build do backend
cd ProductApi/ProductApi
docker build -t products-api .

cd ../..

REM Rodando o Docker Compose
docker-compose up -d

REM Aguardando a tecla Enter para fechar o terminal
pause
