using Microsoft.EntityFrameworkCore;
using ColegioSanJose.Data;
using Microsoft.Extensions.DependencyInjection;

// 1. EL BUILDER SIEMPRE VA PRIMERO
var builder = WebApplication.CreateBuilder(args);

// 2. LUEGO AGREGAS LOS SERVICIOS (DbContext)
// Asegúrate de que aquí diga ApplicationDbContext si eso es lo que usas en tus controladores
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// 3. CONFIGURACIÓN DEL PIPELINE (Lo que ya tenías abajo)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();