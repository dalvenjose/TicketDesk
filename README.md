# TicketDesk

A support-ticket management REST API built with **ASP.NET Core 8** and **Entity Framework Core**, created as a hands-on learning project covering the full lifecycle of a production-style .NET backend — from basic CRUD to layered architecture, relationships, error handling, and structured logging. Authentication, testing, and an AI-powered summarization feature are in progress.

## Tech Stack

- **.NET 8** (ASP.NET Core Web API)
- **Entity Framework Core** + **SQLite**
- **Serilog** (structured logging to console + rolling file)
- **Swagger / OpenAPI** for interactive API documentation
- Repository pattern + Dependency Injection

## Features

- Full CRUD for support tickets (`GET`, `POST`, `PUT`, `DELETE`)
- Nested comments per ticket (one-to-many relationship with eager loading)
- DTOs with data-annotation validation (prevents over-posting, enforces business rules)
- Repository pattern — controllers depend on interfaces, not EF Core directly
- Global exception-handling middleware — clean, safe JSON error responses with a trace ID instead of raw stack traces
- Structured logging via Serilog — every request, database query, and custom event logged with contextual fields

## Project Structure

```
TicketDesk/
├── Controllers/
│   └── TicketsController.cs
├── Models/
│   ├── Ticket.cs
│   └── Comment.cs
├── DTOs/
│   ├── CreateTicketDto.cs
│   ├── UpdateTicketDto.cs
│   ├── CreateCommentDto.cs
│   ├── CommentDto.cs
│   └── TicketDto.cs
├── Repositories/
│   ├── ITicketRepository.cs
│   └── TicketRepository.cs
├── Data/
│   └── TicketDeskDbContext.cs
├── Middleware/
│   └── ExceptionHandlingMiddleware.cs
├── Migrations/
└── Program.cs
```

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 (or any editor with the C# Dev Kit)

### Setup

```bash
# Clone the repo
git clone https://github.com/dalvenjose/TicketDesk.git
cd TicketDesk

# Restore packages
dotnet restore

# Apply EF Core migrations to create the SQLite database
dotnet ef database update

# Run the API
dotnet run
```

The API will start on `https://localhost:<port>` — open `/swagger` in your browser to explore and test endpoints interactively.

## API Endpoints

| Method | Route | Description |
|---|---|---|
| GET | `/api/Tickets` | Get all tickets (with comments) |
| GET | `/api/Tickets/{id}` | Get a single ticket by id |
| POST | `/api/Tickets` | Create a new ticket |
| PUT | `/api/Tickets/{id}` | Update an existing ticket |
| DELETE | `/api/Tickets/{id}` | Delete a ticket (cascades to its comments) |
| POST | `/api/Tickets/{ticketId}/comments` | Add a comment to a ticket |

## Example Request

**POST** `/api/Tickets`
```json
{
  "title": "Printer not working",
  "description": "Office printer jams every time"
}
```

**Response** `201 Created`
```json
{
  "id": 1,
  "title": "Printer not working",
  "description": "Office printer jams every time",
  "status": "Open",
  "createdAt": "2026-10-02T13:12:52.65Z",
  "comments": []
}
```

## Roadmap

- [x] ASP.NET Core Web API fundamentals
- [x] EF Core + SQLite with migrations
- [x] CRUD endpoints
- [x] DTOs and validation
- [x] Repository pattern + Dependency Injection
- [x] One-to-many relationships (tickets ↔ comments)
- [x] Global exception handling + Serilog structured logging
- [ ] JWT authentication and role-based authorization
- [ ] Unit and integration testing (xUnit, Moq)
- [ ] Pagination, filtering, and background jobs
- [ ] AI-powered ticket summarization (LLM integration)

## Why This Project

Built as a structured, stage-by-stage learning path from .NET fundamentals toward building AI-enabled applications — pairing solid backend engineering practices (clean architecture, validation, observability) with the next layer of skills needed for production AI systems (RAG, agents, LLM integration).

## License

This project is for educational purposes.