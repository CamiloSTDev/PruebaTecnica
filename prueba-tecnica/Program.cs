using Microsoft.EntityFrameworkCore;
using PruebaTecnica.data.Context;
using PruebaTecnica.data.Repositories;
using PruebaTecnica.negocio.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// injeccion de las dependencias para los repositorios
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();
builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcaRepository>();

// injeccion de las dependencias para los servicios
builder.Services.AddScoped<IVendedorService, VendedorService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IMarcaService, MarcaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
