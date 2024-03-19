---

# RickMortyAPI

RickMortyAPI é um projeto que fornece uma interface para acessar dados da API do Rick and Morty.

## Descrição

Este projeto foi desenvolvido como parte de um estudo sobre APIs e integração de serviços em .NET Core. Ele oferece endpoints para acessar informações sobre personagens, locais e episódios da famosa série de desenhos animados "Rick and Morty".

## Endpoints
### Characters(Personagens)

- **Obter todos os personagens**: Retorna uma lista de todos os personagens da série.
- **Obter personagem por ID**: Retorna um personagem específico com base no ID fornecido.
- **Obter múltiplos personagens**: Retorna uma lista de personagens com base em uma lista de IDs fornecida.
- **Filtrar personagens**: Retorna uma lista de personagens com base em filtros como nome, status, espécie, tipo e gênero.

### Locations(Localizações)

- **Obter todas as localizações**: Retorna uma lista de todos os localizações da série.
- **Obter localização por ID**: Retorna um localização específico com base no ID fornecido.
- **Obter múltiplos localizações**: Retorna uma lista de localizações com base em uma lista de IDs fornecida.
- **Filtrar localizações**: Retorna uma lista de localizações com base em filtros como nome, tipo e dimensão.

### Episodes(Episódios)

- **Obter todos os episódios**: Retorna uma lista de todos os episódios da série.
- **Obter episódio por ID**: Retorna um episódio específico com base no ID fornecido.
- **Obter múltiplos episódios**: Retorna uma lista de episódios com base em uma lista de IDs fornecida.
- **Filtrar episódios**: Retorna uma lista de episódios com base em filtros como nome, e episodeCode(código do episódio. ex.: S01E01)


## Pré-requisitos

Antes de iniciar, certifique-se de ter instalado:

- [.NET Core SDK](https://dotnet.microsoft.com/download)

## Instalação e Uso

1. Clone o repositório:

```bash
git clone https://github.com/sheilaRReis/RickMortyAPI.git
```

2. Navegue até o diretório do projeto:

```bash
cd RickMortyAPI
```

3. Execute o projeto:

```bash
dotnet run
```

4. Acesse a API em [localhost:5000](http://localhost:5000).

## Contribuição

Contribuições são bem-vindas! Se você encontrar algum problema ou tiver sugestões de melhoria, fique à vontade para abrir uma issue ou enviar um pull request.

## Agradecimentos
- Aos desenvolvedores da [Rick and Morty API](https://rickandmortyapi.com/documentation) 
- [Carlj28](https://github.com/Carlj28), desenvolvedor da versão em .NET, disponível na [documentação](https://rickandmortyapi.com/documentation) 
