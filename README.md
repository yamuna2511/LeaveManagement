# Leave Management System

An ASP.NET Core MVC application for managing employee leave requests, approvals, leave balances, and leave records.

## Features

* Employee leave request management
* Leave approval workflow
* Leave status management
* Entity Framework Core database integration
* SQLite database
* MVC architecture with Controllers, Models, ViewModels, and Views
* EF Core migrations

## Tech Stack

* ASP.NET Core MVC
* C#
* Entity Framework Core
* SQLite
* Razor Views
* HTML / CSS
* .NET

## Project Structure

```text
Controllers/     MVC controllers
Data/            Database context and data configuration
Enums/           Application enums
Migrations/      Entity Framework Core migrations
Models/          Domain models
ViewModels/      View-specific models
Views/           Razor views
wwwroot/         Static files
Program.cs       Application configuration and startup
```

## Getting Started

### Prerequisites

* .NET SDK installed
* Visual Studio or VS Code

### Run the Application

Clone the repository:

```bash
git clone <repository-url>
cd LeaveManagement
```

Restore dependencies:

```bash
dotnet restore
```

Apply database migrations:

```bash
dotnet ef database update
```

Run the application:

```bash
dotnet run
```

Open the URL shown in the terminal to access the application.

## Database

The application uses SQLite for lightweight local database persistence. Database files are excluded from source control using `.gitignore`.

## Purpose

This project was built as a practical ASP.NET Core MVC project to demonstrate C#, MVC architecture, Entity Framework Core, database migrations, and CRUD-based application development.
