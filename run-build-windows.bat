@echo off

REM Build do frontend
cd frontend
docker build -t products-frontend-nextjs .

REM Build do backend
cd frontend
docker build -t products-api .

cd ..

REM Rodando o Docker Compose
docker-compose up -d

REM Aguardando a tecla Enter para fechar o terminal
pause
