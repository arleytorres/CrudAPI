<h1 align="center">
  CRUD API com Autenticação JWT 🛡️
</h1>

<p align="center">
  Uma API RESTful moderna construída com .NET 9 e ASP.NET Core para demonstrar um sistema CRUD seguro com autenticação JWT.
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet" alt=".NET 9">
  <img src="https://img.shields.io/badge/Entity%20Framework-Core-512BD4?style=for-the-badge&logo=dotnet" alt="EF Core">
  <img src="https://img.shields.io/badge/JWT-Authentication-black?style=for-the-badge&logo=jsonwebtokens" alt="JWT">
  <img src="https://img.shields.io/badge/SQLite-3-003B57?style=for-the-badge&logo=sqlite" alt="SQLite">
  <img src="https://img.shields.io/badge/Swagger-UI-85EA2D?style=for-the-badge&logo=swagger&logoColor=white" alt="Swagger">
</p>

## 📋 Tabela de Conteúdos
1. [Sobre](#-sobre-o-projeto)
2. [Recursos](#-recursos)
3. [Como Rodar](#-como-rodar)
4. [Tecnologias](#-tecnologias)
5. [Endpoints](#-api-endpoints)

## 📖 Sobre o Projeto
Este repositório contém o código-fonte de uma API para gerenciamento de clientes. O projeto foi criado para aplicar conceitos de segurança em APIs, especificamente o uso de **JSON Web Tokens (JWT)** para proteger endpoints. A aplicação utiliza uma arquitetura limpa e moderna com as últimas novidades do .NET.

## ✨ Recursos
- ✅ **Autenticação e Autorização**: Endpoints de registro e login com geração de token.
- ✅ **Operações CRUD**: Funcionalidades completas para gerenciar clientes.
- ✅ **Segurança de Senhas**: Hashing de senhas com BCrypt.
- ✅ **Documentação Interativa**: Swagger UI configurado para facilitar os testes.
- ✅ **Tratamento de Erros Centralizado**: Respostas de erro consistentes e claras.

## 🚀 Como Rodar
```bash
# 1. Clone este repositório
$ git clone [https://github.com/arleytorres/CrudAPI.git](https://github.com/arleytorres/CrudAPI.git)

# 2. Navegue até o diretório do projeto
$ cd CrudAPI

# 3. Restaure as dependências
$ dotnet restore

# 4. Inicie a aplicação
$ dotnet run

# A API estará disponível em http://localhost:5205
```

## 🛠️ Tecnologias
Abaixo estão as principais tecnologias utilizadas:
- **.NET 9**
- **ASP.NET Core Minimal APIs**
- **Entity Framework Core**
- **Swagger / OpenAPI**
- **JWT (JSON Web Tokens)**
- **BCrypt.Net-Next**
- **SQLite**

## 🔌 API Endpoints

A documentação completa e interativa pode ser acessada em **/swagger**.

| Método HTTP | Rota                          | Descrição                          | Autenticação |
|-------------|-------------------------------|------------------------------------|--------------|
| `POST`      | `/api/v1/auth/register`       | Registra um novo usuário.          | ❌ Não       |
| `POST`      | `/api/v1/auth/login`          | Realiza o login e retorna um token.| ❌ Não       |
| `GET`       | `/api/v1/clients/getall`      | Lista todos os clientes.           | ✅ Sim       |
| `GET`       | `/api/v1/clients/getbyid/{id}`| Busca um cliente pelo ID.          | ✅ Sim       |
| `POST`      | `/api/v1/clients/insert`      | Cria um novo cliente.              | ✅ Sim       |
| `DELETE`    | `/api/v1/clients/delete/{id}` | Deleta um cliente.                 | ✅ Sim       |
