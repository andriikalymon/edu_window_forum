using FluentValidation;
using Forum.Domain.ViewModels.User;
using Microsoft.Extensions.DependencyInjection;
using Forum.Domain.FluentValidation.User;
using Forum.Domain.FluentValidation.Comment;
using Forum.Domain.ViewModels.Comment;
using Forum.Domain.FluentValidation.Topic;
using Forum.Domain.ViewModels.Topic;

namespace Forum.Web.Extensions
{
    public static class FluentValidationExtension
    {
        public static void AddFluentValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AuthenticateUserViewModel>, AuthenticateUserViewModelValidator>();
            services.AddTransient<IValidator<CommentToAddViewModel>, CommentToAddViewModelValidator>();
            services.AddTransient<IValidator<TopicToCreateViewModel>, TopicToCreateViewModelValidator>();
        }
    }
}
