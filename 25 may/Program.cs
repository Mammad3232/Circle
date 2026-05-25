using _25_may.DAL;
using Microsoft.EntityFrameworkCore;

namespace _25_may
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Server=DESKTOP-LUGHNBO;Database=Pictures;Trusted_Connection=True;TrustServerCertificate=True;");
            });
            var app = builder.Build();

         
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
            app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
          );

            app.UseStaticFiles();
            app.Run();

        }
    }
}
