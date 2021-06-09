using FluentValidation;
using Forum.Domain.ViewModels.Comment;

namespace Forum.Domain.FluentValidation.Comment
{
    public class CommentToAddViewModelValidator : AbstractValidator<CommentToAddViewModel>
    {
        public CommentToAddViewModelValidator()
        {
            RuleFor(comment => comment.Text).NotNull().NotEmpty();
        }
    }
}
