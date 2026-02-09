# Tenisu

A Tennis players management API

[Live demo](https://tenisu.thomasplacais.com)

## Getting Started

### Running the Application

#### Using .NET CLI

```bash
dotnet run --project Tenisu.Web
# Listen on http://localhost:5222
```

#### Using Docker

```bash
docker build -t tenisu .
docker run -p 8080:8080 tenisu
# Listen on http://localhost:8080
```

### Using the application

You can access the application, either on [tenisu.thomasplacais.com](https://tenisu.thomasplacais.com), or by running it locally.

The root endpoint redirects to the [Scalar](https://scalar.com) documentation and API client, that will allow you to use available endpoints.

The available endpoints are:

```
GET  /statistics

GET  /players
GET  /players/{id}
POST /players
```

### Running Tests

```bash
dotnet test
```

## Technical Choices

 - Clean architecture with a project per layer
 - Model validation using built-in data annotation
   - *This method allows validation well integrated with ASP.NET Core with minimal additional code. However it moves validation logic away from the domain layer. I think the tradeoff is acceptable for a small project*
 - Models are shared from the Web to the Infrastructure layer
   - *In a larger project, I would have used Dtos for the Web layer, decouping data representation, extracting JSON Serialization logic to the web layer, and keeping all business logic in the domain layer*
 - In-memory collection in Infrastructure layer
   - *Obviously, in a real application, I would have used a database (sqlite in this scenario) coupled to EF Core. This implementation shows that the Application layer depends on abstractions, and that the Infrastructure layer can be easily swapped without affecting the Application layer*
