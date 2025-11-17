# CycleStoreStarter
Minimal ASP.NET Core MVC starter for an e-commerce site selling cycles.
- SQLite (EF Core)
- Basic Product Catalog, Cart (session), Admin product CRUD, Checkout stub
- No authentication (add Identity later)

## Run locally
1. Install .NET 8 SDK.
2. `dotnet restore`
3. `dotnet run`
4. Open http://localhost:5000

The app will create `cyclestore.db` and seed sample products on first run.
