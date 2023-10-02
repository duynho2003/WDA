using Lab06Domain.Data;
using Lab06Infrastructure.Repository;
using Lab06Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<CustomerRepository, CustomerServices>();
// Add services to the container.
builder.Services.AddControllersWithViews();

//Khai bao Session
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Su dung session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Login}/{id?}");

app.Run();
