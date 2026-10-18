# 🍳 CookBook API

### 👥 Integrantes
* **[João Henrique Pelison Bastos]**
* **[Matheus Teclak Camilo]**
* **[Osmar Cardoso Lopes Filho]**

**🎓 Curso:** [Ciência da Computação]  

---

## 📝 Resumo

<p align="justify">
O CookBook é uma plataforma digital projetada para simplificar a gestão culinária diária, atuando como um assistente inteligente para o mapeamento e o gerenciamento de receitas. Desenvolvido com foco na eficiência e na redução do desperdício de alimentos, o ecossistema armazena de forma estruturada os ingredientes e os passos sequenciais de preparo. O grande diferencial do sistema reside na sua capacidade de cruzar dados em tempo real, permitindo que os usuários descubram instantaneamente quais pratos podem ser cozinhados com base exclusivamente nos insumos que possuem disponíveis em suas dispensas domésticas.
</p>

---

## 🚀 Funcionalidades

* 🥦 **Gerenciamento de Ingredientes:** Cadastro e catalogação de insumos alimentares com suporte a múltiplas unidades de medida.
* ⏱️ **Modelagem de Etapas de Preparo:** Estruturação ordenada e sequencial do passo a passo para a execução de cada prato.
* 🔗 **Vínculo Dinâmico de Receitas:** Associação inteligente que unifica receitas, seus respectivos ingredientes e o modo de preparo.
* 🔍 **Busca Inversa por Insumos:** Algoritmo de cruzamento que localiza receitas viáveis a partir da dispensa informada pelo usuário.

---

## 🔍 Descrição das Funcionalidades

### 🥦 Gerenciamento de Ingredientes
<p align="justify">
Esta funcionalidade provê uma base de dados centralizada para o cadastro de itens alimentícios. Cada ingrediente possui um registro único, o que evita a duplicidade de informações. O sistema permite especificar nomes comerciais ou genéricos, servindo como a fundação para o controle de estoque de despensa dos usuários.
</p>

### ⏱️ Modelagem de Etapas de Preparo
<p align="justify">
As etapas de preparo ditam a linha cronológica de execução da receita. Cada passo é indexado de forma sequencial (ex: Passo 1, Passo 2), contendo instruções textuais detalhadas sobre o que deve ser feito. Essa separação estrutural garante que as instruções de preparo permaneceram organizadas e fáceis de serem renderizadas em qualquer interface visual.
</p>

### 🔗 Vínculo Dinâmico de Receitas (Tabela Pivô)
<p align="justify">
Através de uma arquitetura relacional otimizada, o sistema conecta receitas a múltiplos ingredientes e quantidades específicas (ex: 200g de farinha, 3 unidades de ovos). Esta abordagem separa a existência física do ingrediente em si da quantidade exata exigida por um prato específico, permitindo a reutilização do mesmo insumo em diversas receitas diferentes.
</p>

### 🧮 Busca Inversa por Insumos
<p align="justify">
É o motor de inteligência da API. O usuário envia uma lista com os ingredientes que possui em mãos e o sistema realiza uma varredura na tabela relacional. Ele filtra e retorna apenas as receitas cujos requisitos de ingredientes sejam atendidos integralmente ou parcialmente pelos itens fornecidos, otimizando o uso de mantimentos e sugerindo opções práticas para o dia a dia.
</p>

---

## 🔄 Jornada do Usuário e Fluxo da Aplicação

<p align="justify">
Para garantir uma experiência fluida e otimizar o consumo de dados entre a aplicação web (frontend) e a API (backend), o fluxo de navegação do usuário final foi projetado e dividido em dois passos operacionais sequenciais:
</p>

### 1. Etapa de Busca por Insumos
* **Ação do Usuário:** O usuário abre o aplicativo, visualiza a lista de ingredientes cadastrados no sistema e marca caixas de seleção (checkboxes) indicando apenas os insumos que ele possui em sua dispensa no momento (ex: Ovo, Farinha, Açúcar e Cenoura). *Nesta etapa, o usuário não precisa informar quantidades.*
* **Comportamento do Backend:** A API recebe exclusivamente a lista de IDs desses ingredientes. O sistema executa um cruzamento rápido na tabela pivô `ReceitasIngredientes` e localiza quais receitas têm seus requisitos totalmente preenchidos por aquela dispensa.
* **Retorno Visual:** O backend devolve para a tela uma lista simplificada contendo os nomes das receitas encontradas. Para cada receita da lista, o sistema exibe automaticamente os ingredientes necessários acompanhados de suas respectivas **Quantidades** e **Unidades de Medida** (ex: 3 unidades de Cenoura, 2 xícaras de Farinha), permitindo que o usuário valide se os seus insumos são suficientes em volume.

### 2. Etapa de Detalhes e Modo de Preparo
* **Ação do Usuário:** Após analisar as opções sugeridas pela busca, o usuário decide qual prato deseja cozinhar e **clica em cima do card da receita** escolhida (ex: "Bolo de Cenoura").
* **Comportamento do Backend:** Ao receber o clique, o frontend faz uma nova requisição à API passando o ID único daquela receita específica. O backend faz uma busca direta na tabela principal de `Receitas` e recupera todas as linhas associadas na tabela sequencial de `Etapas`.
* **Retorno Visual:** A tela do aplicativo é atualizada para exibir a ficha técnica completa do prato: o título, a descrição contextual da receita e o **passo a passo cronológico ordenado** (Passo 1, Passo 2, Passo 3, etc.). Essa separação garante que textos longos de instruções de preparo só trafeguem pela rede quando o usuário realmente decidir fazer aquele prato.

---

## 🏛️ Arquitetura e Banco de Dados

<p align="justify">
O backend é construído sobre o ecossistema <strong>ASP.NET Core</strong> utilizando o template de <strong>API Mínima</strong> (<code>dotnet new web</code>), o que confere alta performance e baixa latência ao projeto.
</p>
<br>

Para sustentar as funcionalidades descritas, a modelagem relacional do banco de dados foi estruturada da seguinte forma:


| Tabela | Coluna | Tipo de Dado | Chave | Descrição / Regra |
| :--- | :--- | :--- | :--- | :--- |
| **Receitas** | `Id` <br> `Nome` <br> `Descricao` | Guid <br> VARCHAR <br> TEXT | PK <br> - <br> - | Identificador único global da receita. <br> Nome do prato (ex: "Bolo de Cenoura"). <br> Detalhes ou história do prato. |
| **Ingredientes** | `Id` <br> `Nome` | Guid <br> VARCHAR | PK <br> - | Identificador único do ingrediente na base. <br> Nome do item (ex: "Ovo", "Farinha"). |
| **Etapas** | `Id` <br> `Ordem` <br> `Descricao` <br> `ReceitaId` | Guid <br> INT <br> TEXT <br> Guid | PK <br> - <br> - <br> FK | Identificador único do passo de preparo. <br> Passo sequencial numérico (ex: 1, 2, 3). <br> Instrução clara da ação a ser tomada. <br> Vinculação direta com a receita dona da etapa. |
| **ReceitasIngredientes** <br> *(Tabela Pivô)* | `ReceitaId` <br> `IngredienteId` <br> `Quantidade` <br> `UnidadeMedida` | Guid <br> Guid <br> DECIMAL <br> VARCHAR | PK&nbsp;/&nbsp;FK <br> PK&nbsp;/&nbsp;FK <br> - <br> - | Chave composta. Associa o ingrediente à receita. <br> Chave composta. Associa o ingrediente à receita. <br> Proporção necessária para o prato. <br> Métrica utilizada (ex: "g", "ml", "unidades"). |
  
---

## 🤖 Uso de AI (Inteligência Artificial)

### 🛠️ Ferramenta Utilizada
* **Modelos de Linguagem:** OpenAI ChatGPT (baseado em GPT-4o) e Claude 3.5 Sonnet (via assistente de IA).

### ⚙️ Forma de Uso
* **Geração de Testes Automatizados:** <p align="justify">A ferramenta de IA será integrada ao fluxo de desenvolvimento para analisar a lógica de negócio dos endpoints da API Mínima e gerar cenários de testes unitários e de integração correspondentes.</p>
* **Escrita de Documentação Técnica:** <p align="justify">Utilizada para expandir as notas rascunhadas do projeto em um formato de documentação acadêmica formal, padronizando a descrição das funcionalidades e gerando o layout Markdown da modelagem de dados.</p>
- **Planejamento e organização:** <p align="justify">A IA também será utilizada para auxiliar no planejamento do projeto, ajudando na criação de *issues* no GitHub e na divisão do desenvolvimento em tarefas menores, facilitando a organização e o acompanhamento do progresso da equipe.</p>