# Asset Management System

A full-stack **Asset Management System** developed using **ASP.NET Core MVC**, **ASP.NET Core Web API**, **ADO.NET**, and **SQL Server**.

The application helps organizations efficiently manage employees, assets, categories, asset assignments, and reports through a secure role-based authentication system.

---

# 🚀 Technologies Used

## Frontend

- ASP.NET Core MVC
- Razor Views (.cshtml)
- HTML5
- CSS3
- Bootstrap 5
- HttpClient

## Backend

- ASP.NET Core Web API
- ADO.NET
- Repository Pattern
- Service Layer
- Dependency Injection
- JWT Authentication
- Logging (ILogger)

## Database

- SQL Server

---

# ✨ Features

## Authentication

- Secure Login
- JWT Authentication
- Session Management
- Role-Based Authorization

## Employee Module

- Add Employee
- Update Employee
- Delete Employee
- Employee List
- Search Employee

## Asset Module

- Add Asset
- Update Asset
- Delete Asset
- Asset List

## Category Module

- Add Category
- Update Category
- Delete Category
- Category List

## Asset Assignment

- Assign Assets to Employees
- Return Assigned Assets
- Assignment History

## Dashboard

- Dashboard Overview
- Summary Cards

## Reports

- Employee Reports
- Asset Reports
- Assignment Reports

---

# 🏗️ Project Architecture

```text
                 Browser
                    │
                    ▼
          ASP.NET Core MVC
        (Razor Views + Session)
                    │
               HttpClient
                    │
                    ▼
        ASP.NET Core Web API
                    │
              Controllers
                    │
             Service Layer
                    │
           Repository Layer
                    │
                 ADO.NET
                    │
                    ▼
               SQL Server
```

---

# 📂 Project Structure

```
AssetManagementSystem
│
├── AssetManagement.API
│   ├── Controllers
│   ├── Models
│   ├── Services
│   ├── Repositories
│   └── appsettings.json
│
├── AssetManagement.MVC
│   ├── Controllers
│   ├── Models
│   ├── Views
│   ├── wwwroot
│   └── Services
│
└── AssetManagementSystem.sln
```

---

# 👨‍💻 Developer

**Kunal Ravindra Suryawanshi**

.NET Full Stack Developer | Passionate about building secure, scalable, and user-friendly web applications using ASP.NET Core MVC, ASP.NET Core Web API, ADO.NET, and SQL Server.

📧 **Email:**  
suryawanshikunal011@gmail.com

🔗 **LinkedIn:**  
https://linkedin.com/in/kunalsuryawanshi53

💻 **GitHub Profile:**  
https://github.com/KunalSuryawanshi53

---

# 🚀 How to Run

### 1. Clone the Repository

```bash
git clone https://github.com/KunalSuryawanshi53/Asset-Management-System.git
```

### 2. Open the Solution

Open **AssetManagementSystem.sln** using **Visual Studio 2022**.

### 3. Configure Database

- Open SQL Server.
- Restore/Create the required database.
- Update the **Connection String** in:

```
AssetManagement.API/appsettings.json
```

### 4. Run the Web API

Set **AssetManagement.API** as Startup Project and run it.

### 5. Run the MVC Project

Set **AssetManagement.MVC** as Startup Project and run it.

### 6. Login

Login using valid credentials.

---

# ⭐ Technologies Summary

- ASP.NET Core MVC
- ASP.NET Core Web API
- ADO.NET
- SQL Server
- Repository Pattern
- Dependency Injection
- JWT Authentication
- Bootstrap 5
- HTML5
- CSS3

---

## ⭐ If you like this project, don't forget to Star this repository.
