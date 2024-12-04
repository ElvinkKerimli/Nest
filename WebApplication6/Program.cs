using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL;

namespace WebApplication6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer("server=KERIMOVS;database=Nest;Trusted_connection=true;encrypt=false");
            });
            var app = builder.Build();

            app.MapControllerRoute
               (
               name: "areas",
               pattern: "{area=exists}/{controller=dashboard}/{action=index}"
               );

            app.MapControllerRoute
                (
                name: "default",
                pattern: "{controller=home}/{action=index}"
                );



            app.UseStaticFiles();
            app.Run();
        }
    }
}
