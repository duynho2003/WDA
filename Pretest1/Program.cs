using Pretest1.Models;
using Pretest1.Repository;
using Pretest1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskManagerContext>();
builder.Services.AddScoped<TaskRepository, TaskServices>();
builder.Services.AddSession(); //khai bao session
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Task}/{action=Index}/{id?}");

app.Run();
