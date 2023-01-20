using Microsoft.EntityFrameworkCore;
using Second_Task_BusinessLayer.Interfaces;
using Second_Task_BusinessLayer.Services;
using Second_Task_Data;
using Second_Task_Data.Interfaces;
using Second_Task_Data.Repositories;

namespace Second_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            builder.Services.AddScoped<IExcelManager, ExcelManager>();
            builder.Services.AddScoped<IExcelRepository, ExcelRepository>();
            builder.Services.AddScoped<IFileManager, FileManager>();
            builder.Services.AddTransient<DbContext, ApplicationDbContext>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), q => q.MigrationsAssembly("Second_Task_Data"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging();
            });

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
                pattern: "{controller=Home}/{action=FileManagement}/{id?}");

            app.Run();
        }
    }
}