using Forum.Domain.FluentValidation.Comment;
using FluentValidation.TestHelper;
using Xunit;

namespace Forum.Test.FluentValidation.Comment
{
    public class CommentToAddViewModelValidatorTest
    {
        private readonly CommentToAddViewModelValidator validator;

        public CommentToAddViewModelValidatorTest() => validator = new CommentToAddViewModelValidator();

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Text_IsNullOrEmpty_GeneratesError(string value)
        {
            validator.ShouldHaveValidationErrorFor(c => c.Text, value);
        }

        [Theory]
        [InlineData("comment")]
        public void Text_IsNotNullOrEmpty_NotGeneratesError(string value)
        {
            validator.ShouldNotHaveValidationErrorFor(c => c.Text, value);
        }
    }
}
