using Microsoft.EntityFrameworkCore;
using QMYoga.Components;
using QMYoga.Context;

namespace QMYoga
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<QMYogaContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("QMYogaContext"));
            });

            builder.Services.AddTransient<DbSeeder>();

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbSeeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
                dbSeeder.InitData();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
