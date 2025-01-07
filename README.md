
# Projeto de Conta Bancária

Este projeto é uma aplicação full-stack que envolve um backend em C# com .NET e um frontend em Vue.js. O objetivo é gerenciar transações bancárias, como depósitos e saques.

## Requisitos

- Docker
- .NET SDK
- Node.js
- npm

## Rodando o Backend

1. Navegue até o diretório `backend/src`:

   ```bash
   cd backend/src
   ```

2. Para rodar o backend, você precisa iniciar os containers Docker. Execute o comando:

   ```bash
   docker-compose up -d
   ```

3. Após a inicialização do Docker, você precisa adicionar a migração inicial ao banco de dados. Execute o comando:

   ```bash
   dotnet ef database update Initial --project Infrastructure -s API -c AppDbContext --verbose
   ```

   Esse comando cria as tabelas no banco de dados a partir do contexto `AppDbContext`.

4. Após a aplicar as Migrations, inicie o projeto. Execute o comando:

   ```bash
   dotnet run --project API --urls https://localhost:7185
   ```
   Esse comando inicia o projeto API.

## Rodando o Frontend

1. Navegue até o diretório `frontend/src`:

   ```bash
   cd frontend/src
   ```

2. Para instalar as dependências, execute o comando:

   ```bash
   npm install
   ```

   Isso irá instalar as dependências do projeto fron-end.

3. Para rodar o frontend, execute o comando:

   ```bash
   npm run dev
   ```

   Isso irá iniciar o servidor de desenvolvimento do Vue.js, e você poderá acessar a aplicação no navegador, geralmente em `http://localhost:3000`.
