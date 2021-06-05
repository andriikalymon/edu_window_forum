using Forum.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Forum.Domain.Extensions
{
    public static class DbContextExtension
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ForumContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
        }
    }
}
