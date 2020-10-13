What is the SPA LeilaoWeb?
=====================
This a project made with .Net Core and Angular 2


## How to use - BackEnd
- You will need the latest Visual Studio 2019 and the latest .NET Core SDK. 3.1.4
To know more about how to setup your enviroment visit the [Microsoft .NET Download Guide](https://www.microsoft.com/net/download)

## Technologies implemented:

- ASP.NET Core 3.1 (with .NET Core 3.1)
 - ASP.NET WebApi Core with JWT Bearer Authentication
 - ASP.NET Identity Core
- Entity Framework Core 3.1
- AutoMapper
- FluentValidator
- Swagger UI with JWT support

## Architecture:
- Repository Pattern

## Generate Database
- Generate Leiloes Tables 
- Run Migrations in LeilaoWeb.Data Project
-- Add-Migration tbLeiloes -Context MeuDbContext
-- Update-DataBase tbLeiloes -Context MeuDbContext

- Generate Identity Tables 
-  Run Migrations in LeilaoWeb.API Project
-- Add-Migration tbIndentity -Context ApplicationDbContext
-- Update-DataBase tbIdentity -Context ApplicationDbContext

## How to use - FrontEnd
- You will need the latest Visual Code or similar Editor, and Angular CLI, this project made in 10.1.4 version
Run `npm i` to install dependencies 
Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.
