# Telemarketing

[English version](README.en.md) | [Versão em Português](README.md)

## Description
API for managing telemarketing indicators and data collection. This project was developed using .NET Core and follows Clean Architecture principles.

## Technologies Used
- .NET Core
- Entity Framework Core
- SQL Server
- Clean Architecture
- CQRS (Command Query Responsibility Segregation)

## Project Structure
The project is organized in the following layers:

### Domain
- Entities: Contains the main system entities
- Interfaces: Repository and service contracts

### Application
- Commands: CQRS command implementations
- Queries: CQRS query implementations
- DTOs: Data transfer objects
- Services: Business service implementations

### Infrastructure
- Data: Database context configuration
- Repositories: Repository implementations
- Migrations: Entity Framework migrations

### API
- Controllers: API endpoints
- Program.cs: Application configuration
- appsettings.json: Application settings

## Environment Setup

### Prerequisites
- .NET 7.0 SDK or higher
- SQL Server
- Visual Studio 2022 or VS Code

### Execution Steps
1. Clone the repository
2. Restore NuGet packages:
   ```
   dotnet restore
   ```
3. Run database migrations:
   ```
   dotnet ef database update
   ```
4. Run the project:
   ```
   dotnet run
   ```

## Main Features
- Indicator Management
- Data Collection
- RESTful API

## Contributing
1. Fork the project
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License
This project is under the MIT license. 