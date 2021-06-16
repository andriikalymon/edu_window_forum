using FluentValidation.TestHelper;
using Forum.Domain.FluentValidation.Topic;
using Xunit;

namespace Forum.Test.FluentValidation.Topic
{
    public class TopicToEditViewModelValidatorTest
    {
        private readonly TopicToEditViewModelValidator validator;

        public TopicToEditViewModelValidatorTest() => validator = new TopicToEditViewModelValidator();

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Text_IsNullOrEmpty_GeneratesError(string value)
        {
            validator.ShouldHaveValidationErrorFor(t => t.Text, value);
        }

        [Theory]
        [InlineData("topic")]
        public void Text_IsNotNullOrEmpty_NotGeneratesError(string value)
        {
            validator.ShouldNotHaveValidationErrorFor(t => t.Text, value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Name_IsNullOrEmpty_GeneratesError(string value)
        {
            validator.ShouldHaveValidationErrorFor(t => t.Name, value);
        }

        [Theory]
        [InlineData("topic")]
        public void Name_IsNotNullOrEmpty_NotGeneratesError(string value)
        {
            validator.ShouldNotHaveValidationErrorFor(t => t.Name, value);
        }
    }
}
