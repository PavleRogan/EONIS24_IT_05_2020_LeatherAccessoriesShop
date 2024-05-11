using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Infrastructure.Persistence;
using WebShop.Infrastructure.Seeders;

namespace WebShop.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("WebShopDB");
        services.AddDbContext<WebShopDbContext>(
            options =>
                options.UseSqlServer(connectionString));
        services.AddScoped<IWebShopSeeder, WebShopSeeder>();

    }

}

