using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using WAMVC.Data;
using WAMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar el contexto de base de datos
builder.Services.AddDbContext<ArtesaniasDBContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ============================================
// CONFIGURACI�N DE AUTENTICACI�N
// ============================================
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.SlidingExpiration = true;
    });

// ============================================
// CONFIGURACI�N DE AUTORIZACI�N (POL�TICAS)
// ============================================
builder.Services.AddAuthorization(options =>
{
    // Pol�tica: Solo Administradores
    options.AddPolicy(Policies.RequiereAdministrador, policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole(Roles.Administrador);
    });

    // Pol�tica: Solo Usuarios normales
    options.AddPolicy(Policies.RequiereUsuario, policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole(Roles.Usuario);
    });

    // Pol�tica: Cualquier usuario autenticado (Admin o Usuario)
    options.AddPolicy(Policies.RequiereUsuarioAutenticado, policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireRole(Roles.Administrador, Roles.Usuario);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// A�adir el middleware de autenticaci�n antes de la autorizaci�n
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
