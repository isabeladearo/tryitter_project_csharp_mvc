## Opaaa!! 👊🏻 Tranquilo? Bem-vindo ao Tryitter!!

#### O conhecido Twitter na versão dedicada a estudantes. Esse é um projeto para finalizar uma aceleração em csharp que aborda conceitos para desenvolver uma aplicação API REST.
#### O projeto foi focado 100% no olhar de backend. Foi utilizado para elaborar o banco de dados SQLServer o ORM Entity Framework, como proposta de validação do body das requisições foi utilizado Fluent Validation e, como forma de autenticar o estudante, foi utilizado uma validação com JWT Token. 

##

<details>
<summary><strong>Rodando a aplicação no Docker</summary></strong><br>

  **Para rodar a API localmente utilizando Docker, certifique-se de ter o Docker esteja instalado instalados em sua máquina.**
  1. Clone o repositório 
  * `git clone git@github.com:isabeladearo/tryitter_project_csharp_mvc.git`.
  * Entre na pasta do repositório que você acabou de clonar:
    * `cd tryitter_project_csharp_mvc`
  2. Rode o comando no seu terminal para baixar a imagem do SQL Server
   * `docker pull mcr.microsoft.com/mssql/server`<br><br>
  **OBS**: Para te auxiliar melhor, leia este [artigos](https://balta.io/blog/sql-server-docker).
  3. Assim que o container do SQL já está rodando, atualize a `connectionString` no arquivo `appsettings.json`.
  ```bash
  "ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1,1433;Database=Tryitter;User ID=sa;Password=PASSWORD;TrustServerCertificate=true"
  },
  ```
  4. Rode o comando para criar as tabelas no banco de dados:
  * `dotnet ef database update`
  **OBS**: É ter instalado `EF Core Tools` para rodar esse comando.
  5. Agora é só rodar a aplicação! Ela abrirá direto no Swagger!!
  * `dotnet run`
</details>

##

<details>
<summary><strong>Bora testar a aplicação 😎</summary></strong><br>

**Oriento primeiro a cadastras um estudante. Temos que autenticar o acesso dele para conseguir testar as outras rotas!!**

#### ROTAS PARA LOGAR E CRIAR CONTA
1. > Rota POST para criar conta do estudante
![Screen Shot 2022-12-16 at 15 57 33](https://user-images.githubusercontent.com/92924409/208169475-7efa65d7-95c6-490b-992d-c83f8aa9d50c.png)
2. > Rota POST para logar o estudante
![Screen Shot 2022-12-16 at 16 03 09](https://user-images.githubusercontent.com/92924409/208170240-7ba1a582-fa2f-43b8-ad26-82e173c5d490.png)

**Depois de ter gerado o token, vamos logar na conta?
1. > Clique no botão `Authorize`<br>
![Screen Shot 2022-12-16 at 16 06 57](https://user-images.githubusercontent.com/92924409/208170884-ec33f093-8040-406b-a58d-0aaf77ebe6df.png)
2. Insira a credencial da seguinte forma e clique em `Authorize`:
`Bearer token`
![Screen Shot 2022-12-16 at 16 09 10](https://user-images.githubusercontent.com/92924409/208171142-46e33c77-ef93-4fbe-8a5e-18e930fbdf89.png)

#### ROTAS RELACIONADAS AOS ESTUDANTES
1. > Rota GET para listar todos os estudantes cadastrados
![Screen Shot 2022-12-16 at 16 10 49](https://user-images.githubusercontent.com/92924409/208171397-1338b052-e300-4e22-b291-1bf6ec780ec3.png)
2. > Rota GET para achar o estudante pelo seu `Id`
![Screen Shot 2022-12-16 at 16 11 44](https://user-images.githubusercontent.com/92924409/208171551-7c030851-0c34-4d67-9b5e-b5874c51f978.png)
3. > Rota PUT para atualizar o estudante pelo seu `Id`
![Screen Shot 2022-12-16 at 16 12 50](https://user-images.githubusercontent.com/92924409/208171722-6d603d5f-2493-4feb-adba-20d7e4543a1c.png)
4. > Rota DELETE para deletar o estudante pelo seu `Id`
![Screen Shot 2022-12-16 at 16 13 32](https://user-images.githubusercontent.com/92924409/208171853-ef33dcce-5452-4daf-8c35-ac4f13e833ff.png)
5. > Rota GET para achar o estudante pelo seu `nome`
![Screen Shot 2022-12-16 at 16 14 26](https://user-images.githubusercontent.com/92924409/208172006-70d16d09-9345-45a5-ad66-91ac93807908.png)

#### ROTAS RELACIONADAS AOS POSTS
1. > Rota GET para listar todos os posts cadastrados
![Screen Shot 2022-12-16 at 16 15 11](https://user-images.githubusercontent.com/92924409/208172145-8e908c75-6e76-42c9-bfa6-80e1b0c3ea76.png)
2. > Rota GET para achar o post pelo seu `Id`
![Screen Shot 2022-12-16 at 16 16 21](https://user-images.githubusercontent.com/92924409/208172331-281ccee0-cfca-47a5-a85d-2b18b03fc956.png)
3. > Rota PUT para atualizar o post pelo seu `Id`
![Screen Shot 2022-12-16 at 16 17 15](https://user-images.githubusercontent.com/92924409/208172485-84bda9e8-c127-44a8-b884-6fa6679b03f0.png)
4. > Rota DELETE para deletar o post pelo seu `Id`
![Screen Shot 2022-12-16 at 16 17 50](https://user-images.githubusercontent.com/92924409/208172578-9389c0a1-98b1-4d1b-8fa9-c77f5b1464c7.png)
5. > Rota GET para achar o último post criado
![Screen Shot 2022-12-16 at 16 18 31](https://user-images.githubusercontent.com/92924409/208172683-3830a4da-4cc0-48b3-9b7f-6a223e09e746.png)
</details>

##

<strong>[Vídeo de apresentação 🎬](https://user-images.githubusercontent.com/92924409/208173284-7a16cca2-fea8-4be7-9965-b189053ca2f3.mov)</strong>
</details>
