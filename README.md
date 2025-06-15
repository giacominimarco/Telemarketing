# Telemarketing

[English version](README.en.md) | [Versão em Português](README.md)

## Descrição
API para gerenciamento de indicadores e coletas de telemarketing. Este projeto foi desenvolvido utilizando .NET Core e segue os princípios de Clean Architecture.

## Tecnologias Utilizadas
- .NET Core
- Entity Framework Core
- SQL Server
- Clean Architecture
- CQRS (Command Query Responsibility Segregation)

## Estrutura do Projeto
O projeto está organizado nas seguintes camadas:

### Domain
- Entities: Contém as entidades principais do sistema
- Interfaces: Contratos para repositórios e serviços

### Application
- Commands: Implementações dos comandos CQRS
- Queries: Implementações das queries CQRS
- DTOs: Objetos de transferência de dados
- Services: Implementações dos serviços de negócio

### Infrastructure
- Data: Configuração do contexto do banco de dados
- Repositories: Implementações dos repositórios
- Migrations: Migrações do Entity Framework

### API
- Controllers: Endpoints da API
- Program.cs: Configuração da aplicação
- appsettings.json: Configurações da aplicação

## Configuração do Ambiente

### Pré-requisitos
- .NET 7.0 SDK ou superior
- SQL Server
- Visual Studio 2022 ou VS Code

### Passos para Execução
1. Clone o repositório
2. Restaure os pacotes NuGet:
   ```
   dotnet restore
   ```
3. Execute as migrações do banco de dados:
   ```
   dotnet ef database update
   ```
4. Execute o projeto:
   ```
   dotnet run
   ```

## Funcionalidades Principais
- Gerenciamento de Indicadores
- Coleta de Dados
- API RESTful

## Contribuição
1. Faça um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## Licença
Este projeto está sob a licença MIT.