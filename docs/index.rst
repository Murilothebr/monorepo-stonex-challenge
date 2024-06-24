.. include:: ../README.rst

Project Checklist

===================================

Integration

Docker Compose

- [x] Create a docker-compose.yml file to orchestrate the containers for the backend, frontend, and MongoDB.
- [ ] Include appropriate environment variables for configuration.

Clean Code Practices

- [x] Enforce SOLID principles in both backend and frontend code.
- [x] Ensure meaningful variable/method names and code readability.
- [x] Implement unit tests for critical functionalities.

Delivery

- [ ] Provide separate Docker Compose files for development and production.
- [x] Include clear instructions for setting up and running the entire application in README.
- [ ] Ensure the application is accessible through a browser after Docker Compose execution.

===================================

CI/CD Pipeline
==============

Este pipeline é configurado para ser executado em cada push para a branch `main`. Ele consiste em duas etapas principais: construção e push das imagens Docker, seguidas pela implantação em um servidor remoto usando SSH. Aqui está uma explicação passo a passo do pipeline:

Configuração Geral
------------------

O pipeline é acionado em cada push para a branch `main`.

Jobs
----

Build and Push
~~~~~~~~~~~~~~

Este job é responsável por construir e enviar as imagens Docker para o Docker Hub.

**Passos:**

1. **Configuração de Ambiente**:
   - `DOCKER_HUB_USERNAME`, `DOCKER_HUB_PASSWORD`: Credenciais do Docker Hub.
   - `SSH_HOST`, `SSH_USER`, `SSH_PRIVATE_KEY`: Credenciais para acesso SSH ao servidor.

2. **Checkout do Código**:
   - Usando `actions/checkout@v3` para clonar o repositório no ambiente de execução.

3. **Set up Docker Buildx**:
   - Usando `docker/setup-buildx-action@v2` para configurar o Docker Buildx, que permite a construção de imagens multi-arquitetura.

4. **Login no Docker Hub**:
   - Usando `docker/login-action@v3` para autenticar no Docker Hub com as credenciais fornecidas.

5. **Build e Push do Container 1**:
   - Usando `docker/build-push-action@v5` para construir e enviar a imagem do `ProductApi`.
   - **Contexto**: `./ProductApi/ProductApi/`
   - **Dockerfile**: `./ProductApi/ProductApi/Dockerfile`
   - **Tags**: `${{ env.DOCKER_HUB_USERNAME }}/products-api:latest`

6. **Build e Push do Container 2**:
   - Usando `docker/build-push-action@v5` para construir e enviar a imagem do `frontend`.
   - **Contexto**: `./frontend/`
   - **Dockerfile**: `./frontend/Dockerfile`
   - **Tags**: `${{ env.DOCKER_HUB_USERNAME }}/products-frontend:latest`

Deploy
~~~~~~

Este job é responsável por implantar as imagens construídas no servidor remoto.

**Passos:**

1. **Checkout do Código**:
   - Usando `actions/checkout@v4` para clonar o repositório no ambiente de execução.

2. **Setup SSH**:
   - Usando `webfactory/ssh-agent@v0.9.0` para configurar o agente SSH com a chave privada fornecida.

3. **Adicionar Hosts SSH Conhecidos**:
   - Usando `ssh-keyscan` para adicionar o host remoto à lista de hosts conhecidos para evitar problemas de autenticação.

4. **Listar Arquivos**:
   - Comando `ls` para verificar o conteúdo do diretório atual (opcional e útil para debug).

5. **Copiar docker-compose.yaml para o Servidor**:
   - Usando `scp` para copiar o arquivo `docker-compose.yaml` para o servidor remoto no diretório `~/`.

6. **SSH e Pull das Imagens Mais Recentes**:
   - Usando `ssh` para acessar o servidor remoto e executar `docker-compose pull`, que puxa as imagens mais recentes.

7. **SSH e Executar docker-compose up**:
   - Usando `ssh` para acessar o servidor remoto e executar `docker-compose up -d`, que inicia os contêineres em segundo plano.

Resumo
------

Este pipeline automatiza o processo de construção e implantação da aplicação. Ele clona o repositório, constrói as imagens Docker, envia essas imagens para o Docker Hub, e, em seguida, implanta as imagens mais recentes em um servidor remoto usando Docker Compose via SSH. Com esta configuração, você garante que cada push para a branch `main` resulte em uma nova versão da aplicação sendo automaticamente construída e implantada.

