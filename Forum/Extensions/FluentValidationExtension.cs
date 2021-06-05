using FluentValidation;
using Forum.Domain.ViewModels.User;
using Microsoft.Extensions.DependencyInjection;
using Forum.Domain.FluentValidation.User;

namespace Forum.Web.Extensions
{
    public static class FluentValidationExtension
    {
        public static void AddFluentValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AuthenticateUserViewModel>, AuthenticateUserViewModelValidator>();
        }
    }
}
