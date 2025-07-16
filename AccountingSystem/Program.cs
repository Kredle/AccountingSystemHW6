
using AccountingSystem.Data;
using AccountingSystem.Mappings;
using AccountingSystem.Repositories.Categories;
using AccountingSystem.Repositories.Purchases;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AcountingDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("AccountingConnectionString")));
            builder.Services.AddScoped<IPurchaseCategoryRepository, SQLServerCategoryRepository>();
            builder.Services.AddScoped<IPurchaseRepository, SQLServerPurchaseRepository>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllers();

            app.Run();
        }
    }
}
