# Capstone Project: Supply Chain Management Web Application

## 🔍 Project Overview

A web-based application for planning and managing supply chain processes—from procurement to shipment—developed as a capstone project. Built using ASP.NET Core MVC with a layered architecture (Entities, Repositories, Services, MVCApp).

## 🏗️ Architecture & Structure

```
CapstoneProject-SupplyChainManagement/
├─ Entities/                # Data models and DTOs
│  ├─ AuthModels/           # Authentication-related models
│  ├─ DataTransferObjects/  # DTOs for input/output
│  ├─ Enums/                # Enumeration types
│  └─ Models/               # Core domain models
├─ Repositories/            # Data access layer
│  ├─ Config/               # EFCore configurations
│  ├─ Contracts/            # Repository interfaces
│  └─ EFCore/               # Entity Framework implementations
├─ Services/                # Business logic layer
│  ├─ Contracts/            # Service interfaces
│  └─ [ServiceClasses]      # Service class implementations
├─ MVCApp/                  # Presentation layer
│  ├─ Controllers/          # MVC controllers
│  ├─ Infrastructure/       # Middleware, extensions, filters
│  ├─ Views/                # Razor views by controller
│  ├─ wwwroot/              # Static assets (CSS, JS, images)
│  └─ Program.cs            # App startup, DI and middleware
├─ .gitignore               # Ignore build artifacts and secrets
├─ README.md                # Project documentation
└─ SupplyChainManagement.sln # Solution file
```

## 🚀 Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* SQL Server (Express or higher) or a compatible database
* Visual Studio 2022 / VS Code or preferred IDE

## 🛠️ Setup & Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/Dreamment/CapstoneProject-SupplyChainManagement.git
   cd CapstoneProject-SupplyChainManagement
   ```

2. **Configure Connection String**

   * Open `MVCApp/appsettings.json`
   * Set your database connection under `ConnectionStrings:DefaultConnection`

3. **Restore & Build**

   ```bash
   dotnet restore
   dotnet build
   ```

4. **Database Migration**

   ```bash
   cd MVCApp
   dotnet ef database update
   ```

5. **Run the Application**

   ```bash
   cd MVCApp
   dotnet run
   ```

   Navigate to `http://localhost:5285` in your browser.

## 🗂️ Folder Responsibilities

* **Entities**: Define domain models, enums, and DTOs for data transfer.
* **Repositories**: Abstract database access via interfaces; implementations use EF Core.
* **Services**: Contain business rules and interact with repositories.
* **MVCApp**: Hosts controllers, views, and application configuration.

## 🛡️ Key Features

* Role-based authentication and authorization
* CRUD operations for tenders and bids
* EF Core Code-First migrations
* Dependency Injection across layers
* Clean separation of concerns following SOLID principles

## 📈 Technologies Used

* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* C# 11
* Razor Pages
* Bootstrap 5

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m "Add new feature"`)
4. Push to branch (`git push origin feature/YourFeature`)
5. Open a Pull Request

## 📞 Contact

* **Project Owner**: [Dreamment](https://github.com/Dreamment)
* **Email**: [emre_savas28@hotmail.com](mailto:emre_savas28@hotmail.com)

---

*Last updated: May 28, 2025*
