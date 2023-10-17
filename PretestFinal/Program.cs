using PretestFinal.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TrainDbContext>();
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

app.UseRouting();
app.UseSession(); //su dung session
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Train}/{action=Index}/{id?}");

app.Run();
