using AssetManagement.API.Data;
using AssetManagement.API.Interfaces;
using AssetManagement.API.Middleware;
using AssetManagement.API.Repositories;
using AssetManagement.API.Services;
using AssetManagementSystem.Interfaces;
using AssetManagementSystem.Repositories;
using AssetManagementSystem.Repositories.Interfaces;
using AssetManagementSystem.Services;
using AssetManagementSystem.Services.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ================= SERILOG =================

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File(
        "Logs/log-.txt",
        rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// ===========================================

// Add Services

builder.Services.AddControllers();

// ================= JWT Authentication =================

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// ======================================================

// Dependency Injection

builder.Services.AddScoped<DbConnectionFactory>();

// Department
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

// Employee
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

// Asset
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<IAssetService, AssetService>();

// Category
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Asset Assignment
builder.Services.AddScoped<IAssetAssignmentRepository, AssetAssignmentRepository>();
builder.Services.AddScoped<IAssetAssignmentService, AssetAssignmentService>();

// Report
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportService, ReportService>();

// User
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


// JWT
builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddOpenApi();

var app = builder.Build();


// ================= SERILOG REQUEST LOGGING =================

app.UseSerilogRequestLogging();

// ==========================================================

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


// ================= Global Exception Middleware =================

app.UseMiddleware<ExceptionMiddleware>();

// ================================================================


// ================= JWT Middleware =================

app.UseAuthentication();

app.UseAuthorization();

// =================================================

app.MapControllers();

app.Run();