using Forum.Domain.FluentValidation.User;
using FluentValidation.TestHelper;
using Xunit;

namespace Forum.Test.FluentValidation.User
{
    public class AuthenticateUserViewModelValidatorTest
    {
        private readonly AuthenticateUserViewModelValidator validator;

        public AuthenticateUserViewModelValidatorTest() => validator = new AuthenticateUserViewModelValidator();

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Email_IsNullOrEmpty_GeneratesError(string value)
        {
            validator.ShouldHaveValidationErrorFor(u => u.Email, value);
        }

        [Theory]
        [InlineData("email@gmail.com")]
        public void Email_IsValid_NotGeneratesError(string value)
        {
            validator.ShouldNotHaveValidationErrorFor(u => u.Email, value);
        }

        [Theory]
        [InlineData("emailgmail.com")]
        public void Email_IsNotValid_GeneratesError(string value)
        {
            validator.ShouldHaveValidationErrorFor(u => u.Email, value);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Password_IsNullOrEmpty_GeneratesError(string value)
        {
            validator.ShouldHaveValidationErrorFor(u => u.Password, value);
        }

        [Theory]
        [InlineData("email")]
        public void Password_IsNotNullOrEmpty_NotGeneratesError(string value)
        {
            validator.ShouldNotHaveValidationErrorFor(u => u.Password, value);
        }

        [Theory]
        [InlineData("password")]
        public void Password_IsValid_NotGeneratesError(string value)
        {
            validator.ShouldNotHaveValidationErrorFor(u => u.Password, value);
        }

        [Theory]
        [InlineData("pass")]
        public void Password_IsShort_GeneratesError(string value)
        {
            validator.ShouldHaveValidationErrorFor(u => u.Password, value);
        }

        [Theory]
        [InlineData("passwordpasswordpassword")]
        public void Password_IsLong_GeneratesError(string value)
        {
            validator.ShouldHaveValidationErrorFor(u => u.Password, value);
        }
    }
}
