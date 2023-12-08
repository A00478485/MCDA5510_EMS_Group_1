using EMS_App.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace EMS_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EMSContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EMSContext") ?? throw new InvalidOperationException("Connection string 'EMSContext' not found.")));

            builder.Services.AddControllers(options =>
            {
                options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

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
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}