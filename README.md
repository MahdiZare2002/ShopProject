# ShopProject (.NET 8, Onion Architecture, CQRS, Unit of Work)

This project is a backend application built with ASP.NET Core for educational purposes. It demonstrates a clean and scalable architecture using:

- ✅ **Onion Architecture** for layered separation of concerns
- ✅ **CQRS (Command Query Responsibility Segregation)** with MediatR
- ✅ **Unit of Work & Generic Repository** for transactional data access
- ✅ **EF Core** for database interactions
- ✅ **MediatR** for in-process messaging
- ✅ **DTOs** for decoupling domain models from external layers

---

## 🗂️ Project Structure
```text
ShopProject/
│
├── ShopProject.WebApi           → API entry point (Controllers, Program.cs)
├── ShopProject.Application      → CQRS Handlers, Commands, Queries, DTOs
├── ShopProject.Domain           → Entities, Enums, and Domain Rules
├── ShopProject.Infrastructure  → EF Core DbContext, Repositories, UnitOfWork
```
---

## 🛠️ Tech Stack

- ASP.NET Core 8
- Entity Framework Core
- MediatR (CQRS)
- SQL Server (or any configured provider)
- FluentValidation (optional for command validation)

---

## 🚀 How to Run

1. Set up the connection string in `appsettings.json` (in WebApi).
2. Add migrations (if not done):
   ```bash
    dotnet ef migrations add InitialCreate --project ShopProject.Infrastructure --startup-project ShopProject.WebApi
    dotnet ef data



3. Run the project:
   ```bash
    dotnet run --project ShopProject.WebApi
