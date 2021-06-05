using Microsoft.Extensions.DependencyInjection;
using Forum.Data.Entities;
using Forum.Data.Infrastructure;

namespace Forum.Web.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Comment>, Repository<Comment>>();
            services.AddScoped<IRepository<Topic>, Repository<Topic>>();
            services.AddScoped<IRepository<Tag>, Repository<Tag>>();
        }
    }
}
