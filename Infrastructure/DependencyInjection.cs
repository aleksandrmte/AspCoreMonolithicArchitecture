using ApplicationCore.Common.Interfaces;
using ApplicationCore.TodoLists.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(DataContext).Assembly.FullName)));
            
            services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
                    options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultUI();

            services.AddTransient<IIdentityService, IdentityService>();

            services.AddScoped<ITodoListRepository, TodoListRepository>();

            return services;
        }
    }
}
