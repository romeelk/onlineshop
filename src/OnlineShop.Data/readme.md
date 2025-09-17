# Using Entity Framework

The OnlineShop.Data project uses native .NET entity framework core ORM to generate database model via
code.

## Generating migrations

Run the following in the data project

```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
```