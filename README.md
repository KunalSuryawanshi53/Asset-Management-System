# Asset Management System

A full-stack Asset Management System developed using **ASP.NET Core MVC**, **ASP.NET Core Web API**, **ADO.NET**, and **SQL Server**. The application helps organizations manage employees, assets, categories, asset assignments, and reports through a secure role-based system.

---

## 🚀 Technologies Used

### Frontend
- ASP.NET Core MVC
- Razor Views (.cshtml)
- HTML5
- CSS3
- Bootstrap 5
- JavaScript
- HttpClient

### Backend
- ASP.NET Core Web API
- ADO.NET
- Repository Pattern
- Service Layer
- Dependency Injection
- JWT Authentication
- Logging (ILogger)

### Database
- SQL Server

---

## ✨ Features

### Authentication
- Secure Login
- JWT Authentication
- Session Management
- Role-Based Authorization

### Employee Module
- Add Employee
- Update Employee
- Delete Employee
- Employee List
- Search Employee

### Asset Module
- Asset CRUD Operations

### Category Module
- Category CRUD Operations

### Asset Assignment
- Assign Assets
- Return Assets

### Dashboard
- Dashboard Overview

### Reports
- Reports Module

---

## 🏗️ Project Architecture

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
Controller
   │
Service Layer
   │
Repository Layer
   │
ADO.NET
   │
SQL Server
