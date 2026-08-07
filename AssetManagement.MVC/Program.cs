using AssetManagement.MVC.Interfaces;
using AssetManagement.MVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Account Service
builder.Services.AddHttpClient<IAccountService, AccountService>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

// Asset Service
builder.Services.AddHttpClient<IAssetService, AssetService>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

// Category Service
builder.Services.AddHttpClient<ICategoryService, CategoryService>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

// Employee Service
builder.Services.AddHttpClient<IEmployeeService, EmployeeService>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

// Department Service
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

// Asset Assignment Service
builder.Services.AddHttpClient<IAssetAssignmentService, AssetAssignmentService>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

//  Report Dashboard
builder.Services.AddHttpClient<IReportService, ReportService>((serviceProvider, client) =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();

    client.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]!);
});

// Session
builder.Services.AddSession();

// HttpContext Accessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();