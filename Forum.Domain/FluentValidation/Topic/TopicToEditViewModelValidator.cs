using FluentValidation;
using Forum.Domain.ViewModels.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.FluentValidation.Topic
{
    public class TopicToEditViewModelValidator : AbstractValidator<TopicToEditViewModel>
    {
        public TopicToEditViewModelValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Topic title is required");
            RuleFor(t => t.Text).NotEmpty().WithMessage("Topic text is required");
        }
    }
}
