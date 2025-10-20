# 📚 LivrariaAPI

Projeto desenvolvido como parte do meu aprendizado em desenvolvimento de **APIs com C# e .NET**, sendo meu **primeiro projeto utilizando requisições HTTP** e, posteriormente, **integrado com banco de dados SQL Server usando Entity Framework Core**.

---

## 🚀 Sobre o projeto

A **LivrariaAPI** simula o funcionamento de uma livraria digital, permitindo o **cadastro, listagem, atualização e exclusão de livros** através de **endpoints HTTP**.

O projeto evoluiu para incluir persistência de dados usando **SQL Server** e **Entity Framework Core**, implementando práticas reais para APIs que precisam armazenar dados de forma confiável.

---

## 🧠 Aprendizados Técnicos

* Criação de APIs RESTful usando ASP.NET Core;
* Manipulação de requisições HTTP (GET, POST, PUT, DELETE);
* Boas práticas em nomeação de rotas, status codes e tratamento de erros;
* Documentação e testes de API com **Swagger** e **Postman**;
* Configuração do **Entity Framework Core** para trabalhar com SQL Server;
* Criação e aplicação de migrations para versionamento do banco de dados;
* Uso do **DbContext** para manipulação do banco;
* Injeção de dependência e organização em camadas (controllers, services, repositories).

---

## 🛠️ Tecnologias Utilizadas

* **C# / .NET 6 (ou versão usada)**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **Swagger** para documentação interativa
* **Visual Studio / Visual Studio Code**

---

## ⚙️ Como executar o projeto

1. Clone o repositório:

   ```bash
   git clone https://github.com/Vitzero/LivrariaAPI.git
   cd LivrariaAPI

2. Abra o projeto no Visual Studio ou VS Code.

3. Configure a connection string do banco de dados no arquivo appsettings.json:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LivrariaDb;Trusted_Connection=True;"
}

4. Abra o terminal ou Package Manager Console e aplique as migrations para criar o banco e tabelas:

dotnet ef database update

ou, no Package Manager Console do Visual Studio:

Update-Database

5. Execute a aplicação:

dotnet run

6. Acesse o Swagger para testar os endpoints via navegador:

https://localhost:<porta>/swagger
