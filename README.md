# CookBook

O projeto _CookBook_ é uma API (e futuramente site) onde o usuário pode
registrar, pesquisar e gerenciar ingredientes, etapas e receitas. A ferramenta
também oferece a capacidade de pesquisar quais receitas são possíveis a partir
de um conjunto de ingredientes que o usuário possua.

## Backend
O backend existe dentro do projeto `Api` e utiliza o ASP.NET, implementado uma API minima.
Template inicial:
```dotnet new web```

A estrutura de banco de dados é separado em 3 tabelas principais:
- Ingredientes
- Etapas
- Receitas

Além de uma tabela pivô para relacionar uma receita com vários ingredientes e etapas:
- ReceitasIngredientesEtapas

(elaborar aqui talvez)

## Frontend
(no futuro)

## Uso de AI Generativa
O projeto utiliza ferramentas de AI generativa na criação de testes a partir de código existente.
