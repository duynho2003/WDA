using Lab05.Models;
using Lab05.Repository;
using Lab05.Services;

var builder = WebApplication.CreateBuilder(args);

//Call Connect DB
builder.Services.AddDbContext<DatabaseContext>();
//DI
builder.Services.AddScoped<CourseRepository,CourseServices>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Course}/{action=Index}/{id?}");

app.Run();
