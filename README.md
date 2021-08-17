# BlueModas

Este projeto foi criado para mostrar o conhecimento que possuo na criação de aplicações utilizando **.NET Core 5** (utilizando CQRS), **Angular 12** e **SQL Server**.

>Embora tenha sido utilizado o padrão CQRS para separação de comandos e queries, o banco de dados utilizado na aplicação é o mesmo para as duas divisões.

>Não foi dada muita atenção a estilização do front-end pois a ideia é mostrar a estrutura com a qual sou apto a lidar.

### O back-end é separado nas camadas de:
- Apresentação 
>Cliente Angular + aplicação ASP.NET Core.
- Aplicação 
>**AutoMapper**, Interfaces, View Models e Serviços da aplicação.
- Domínio 
>**Comandos**, modelos de domínio, interfaces do repositório e Validações utilizando **Fluent Validation**.
- Infraestrutura 
>Configuração de **Domain Events**, **Injeção de dependência**, **Entity Framework Core** e repositórios.

## Rodando o código

Para rodar o código é preciso instalar as dependências do projeto e criar a base de dados. 

## Criando a base de dados (com o Visual Studio)

-É necessário ajustar a string de conexão do banco de dados em **appsettings.Development.json** no projeto **BlueModas**;

-O projeto **BlueModas** deve ser definido como **projeto de inicialização**; 

-O projeto padrão no **console do gerenciador de pacotes** seja **BlueModas.Infra.Data**;

-Rodar o comando **update-database** para aplicar a migração para criar e popular a base de dados.
