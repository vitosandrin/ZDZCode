
# Projeto de Conta Bancária

Este projeto é uma aplicação full-stack que envolve um backend em C# com .NET e um frontend em Vue.js. O objetivo é gerenciar transações bancárias, como depósitos e saques.

## Requisitos

- Docker
- .NET SDK
- Node.js
- npm

## Rodando o Backend

1. Navegue até o diretório `backend/src/Infrastructure`:

   ```bash
   cd backend/src/Infrastructure
   ```

2. Para rodar o backend, você precisa iniciar os containers Docker. Execute o comando:

   ```bash
   docker-compose up -d
   ```

3. Após a inicialização do Docker, você precisa adicionar a migração inicial ao banco de dados. Execute o comando:

   ```bash
   dotnet ef migrations add Initial --project Infrastructure -s API -c AppDbContext --verbose
   ```

   Esse comando cria as tabelas no banco de dados a partir do contexto `AppDbContext`.

## Rodando o Frontend

1. Navegue até o diretório `frontend/src`:

   ```bash
   cd frontend/src
   ```

2. Para rodar o frontend, execute o comando:

   ```bash
   npm run dev
   ```

   Isso irá iniciar o servidor de desenvolvimento do Vue.js, e você poderá acessar a aplicação no navegador, geralmente em `http://localhost:3000`.

## Contribuindo

1. Faça um fork deste repositório.
2. Crie uma branch para suas alterações (`git checkout -b minha-feature`).
3. Faça commit das suas alterações (`git commit -am 'Adiciona nova feature'`).
4. Envie para o repositório remoto (`git push origin minha-feature`).
5. Abra um pull request para a branch principal.

## Licença

Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
