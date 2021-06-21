using AutoFixture.Xunit2;
using FluentAssertions;
using Forum.Web.Utils;
using Xunit;

namespace Forum.Test.Utils
{
    public class ArrayServiceTest
    {
        [Theory]
        [AutoData]
        public void ConcatArray_IfOptionsIsSpecified_ReturnsArrayWithValue(string[] array, string[] optional)
        {
            // Arrange 
            var firstOfOptional = optional[0];

            // Act
            var actualResult = ArrayService.ConcatArray(array, optional);

            // Assert
            actualResult.Should().Contain(firstOfOptional);
        }

        [Theory]
        [AutoData]
        public void ConcatArray_IfArrayIsSpecified_ReturnsArrayWithValue(string[] array, string[] optional)
        {
            // Arrange 
            var firstOfArray = array[0];

            // Act
            var actualResult = ArrayService.ConcatArray(array, optional);

            // Assert
            actualResult.Should().Contain(firstOfArray);
        }
    }
}
