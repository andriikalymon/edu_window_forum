using FluentAssertions;
using Forum.Web.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Forum.Test.Utils
{
    public class SearchServiceTest
    {
        [Theory]
        [InlineData("name", new string[] { "val", "surname" })]
        public void Match_IfIsRelevant_ReturnTrue(string value, string[] options)
        {
            // Act
            var result = SearchService.Match(value, options);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("age", new string[] { "val", "surname" })]
        public void Match_IfIsNotRelevant_ReturnFalse(string value, string[] options)
        {
            // Act
            var result = SearchService.Match(value, options);

            // Assert
            result.Should().BeFalse();
        }
    }
}
