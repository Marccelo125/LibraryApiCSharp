# Library Api in C#

Esta é uma API construída em C# usando .NET 8 para gerenciar autores e livros. Ela permite adicionar, listar, editar e excluir informações sobre autores e livros.

## Funcionalidades

- **Autores**
    - Listar todos os autores.
    - Adicionar um novo autor.
    - Atualizar informações de um autor existente.
    - Excluir um autor.

- **Livros**
    - Listar todos os livros.
    - Adicionar um novo livro.
    - Atualizar informações de um livro existente.
    - Excluir um livro.

## Pré-requisitos

- .NET SDK 8.0
- Banco de dados SQL (opcional: SQLite para desenvolvimento rápido)

## Configuração do Projeto

1. Clone o repositório:

   ```bash
   git clone <url-do-repositorio>
   cd nome-do-projeto
   ```
2. Configure a string de conexão do banco de dados no arquivo `appsettings.json`.
3. Execute as migrações para criar o banco de dados:
   ```bash
   dotnet ef database update
   ```
   
4. Execute o projeto:
   ```bash
   dotnet run
   ```
   
## Testando a API

Use ferramentas como Postman ou curl para enviar requisições para a API e testar as funcionalidades dos endpoints.