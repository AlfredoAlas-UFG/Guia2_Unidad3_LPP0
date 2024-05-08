using Guia2_Unidad3_AlfredoAlas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Guia2_Unidad3_AlfredoAlas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Listen(System.Net.IPAddress.Any, 5002); // Escucha para HTTP en el puerto 5002
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configuración del DbContext con la cadena de conexión dinámica
            builder.Services.AddDbContext<BDD_UFGContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("conexion")
                    .Replace("placeholder_server", builder.Configuration["DB_SERVER"])
                    .Replace("placeholder_user", builder.Configuration["DB_USER"])
                    .Replace("placeholder_password", builder.Configuration["DB_PASSWORD"])
                ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}