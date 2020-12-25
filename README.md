# RecomendadosYTAPI

> API para praticar o uso de Design Patterns em .NET

## Rodar a API

Basta clonar o repositorio, e então rodar na linha de comando "dotnet run" ou apertar F5 no VSCode.
PS: Necessário ter instalado no computador SDK do .NET Core 3.1

## Usar a API

A documentação do swagger se encontra em localhost:5000/swagger, lá é possível ver os parâmetros para requisição GET e as respostas do servidor. No momento, a API apenas muda de idioma conforme o país fornecido (BR = Brasil, FR = França, US = Estados Unidos)

## TypeError: failed to fetch

Se ao tentar consumir o endpoint da API você se deparar com esse problema, tente consumi-la usando o GET do navegador nativo, passando os parâmetros numa query (por exemplo: localhost:5000/api/Youtube/Recomendados?country=BR&FaixaEtaria=adolescente)
