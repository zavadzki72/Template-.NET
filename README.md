<center><img src="https://winaero.com/blog/wp-content/uploads/2017/08/netcore2-banner.png" alt=".NET image" /></center>


Qual o intuito do repositorio Template .NET?
=====================
O Repositorio tem a função de auxiliar na construção de futuros projetos sendo usado como um template de estrutura.
Nesse caso o exemplo usado como template foi <b>Times de Futebol</b>. 

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/058f16859513412cb7e2e6139d90817e)](https://www.codacy.com/gh/zavadzki72/FirebaseAuthentication/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=zavadzki72/FirebaseAuthentication&amp;utm_campaign=Badge_Grade)

## Como usar
- Você precisa do Visual Studio 2019 e da versão **5** do .NET Core SDK.
- Você pode encontrar os downloads do .net CORE SDK aqui: https://dot.net/core.
- Caso queira, na raiz do projeto existe um `docker-compose.yml` para levantar as dependencias do projeto (Rabbitmq, ElasticSeach, PostgreSql).

## Estrutura
<img src="http://i.prntscr.com/jSOswr3BShCYKcL5g-nHSA.png" alt="Print da estrutura" />


## Tecnologias implementadas

 - .NET 5
 - [EntityFramework (Npgsql)](https://docs.microsoft.com/en-us/ef/)
 - [ElasticSearch](https://www.elastic.co/guide/index.html)
 - [Documentação OpenAPI](https://swagger.io/specification/)
 - [DomainDriveDesign](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)
 - [RabbitMq (Usando o MassTransit)](https://masstransit-project.com/usage/transports/rabbitmq.html#configuration)
 - [MediatR](https://github.com/jbogard/MediatR)
 - [AutoMapper](https://automapper.org)

## Futuras implementações

 - Caching (MemoryCache e Redis)
 - Autenticação Jwt
 - Site para mostrar as informações (WebMvc)
 - Implementação de Testes de Unidade

## Me da uma estrela! :star:
Se você curtiu esse Template, da um star aí!

## Sobre
Esse template foi construido por [Marccus Zavadzki](https://github.com/zavadzki72).
