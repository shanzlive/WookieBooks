using FluentAssertions;
using System;
using WookieBooks.Application.Commands.AddBook;
using Xunit;

namespace WookieBooks.Application.Test
{
    public class AddBookCommandValidatorTests
    {
        private readonly AddBookCommandValidator _validator = new();
        private const string ValidTitle = "Hamlet";
        private const string ValidDescription = "The play by William Shakespeare";
        private const string ValidAuthor = "William Shakespeare";
        private const string ValidCoverImage = "hamet.jpg";
        private const decimal ValidPrice = 100;
        [Fact]
        public void Validate_WhenAllPropertiesAreValid_Istrue()
        {
            //Arrange
            var command = new AddBookCommand(ValidTitle, ValidDescription, ValidAuthor, ValidCoverImage, ValidPrice);

            // Act 
            var result = _validator.Validate(command);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_WhenTitleIsEmpty_IsFalse(string title)
        {
            //Arrange
            var command = new AddBookCommand(title, ValidDescription, ValidAuthor, ValidCoverImage, ValidPrice);

            // Act 
            var result = _validator.Validate(command);

            //Assert
            result.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_WhenAuthorIsEmpty_IsFalse(string author)
        {
            //Arrange
            var command = new AddBookCommand(ValidTitle, ValidDescription, author, ValidCoverImage, ValidPrice);

            // Act 
            var result = _validator.Validate(command);

            //Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
