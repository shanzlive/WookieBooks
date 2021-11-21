using FluentAssertions;
using System;
using WookieBooks.Application.Commands.UpdateBook;
using Xunit;

namespace WookieBooks.Application.Test
{
    public class UpdateBookCommandValidatorTests
    {
        private readonly UpdateBookCommandValidator _validator = new();
        private const int ValidId = 1;
        private const string ValidTitle = "Hamlet";
        private const string ValidDescription = "The play by William Shakespeare";
        private const string ValidAuthor = "William Shakespeare";
        private const string ValidCoverImage = "hamet.jpg";
        private const decimal ValidPrice = 100;
        [Fact]
        public void Validate_WhenAllPropertiesAreValid_Istrue()
        {
            //Arrange
            var command = new UpdateBookCommand(ValidId, ValidTitle, ValidDescription, ValidAuthor, ValidCoverImage, ValidPrice);

            // Act 
            var result = _validator.Validate(command);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_WhenIdIsInvalid_IsFalse(int id)
        {
            //Arrange
            var command = new UpdateBookCommand(id, ValidTitle, ValidDescription, ValidAuthor, ValidCoverImage, ValidPrice);

            // Act 
            var result = _validator.Validate(command);

            //Assert
            result.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_WhenTitleIsInvalid_IsFalse(string title)
        {
            //Arrange
            var command = new UpdateBookCommand(ValidId, title, ValidDescription, ValidAuthor, ValidCoverImage, ValidPrice);

            // Act 
            var result = _validator.Validate(command);

            //Assert
            result.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_WhenAuthorIsInvalid_IsFalse(string author)
        {
            //Arrange
            var command = new UpdateBookCommand(ValidId, ValidTitle, ValidDescription, author, ValidCoverImage, ValidPrice);

            // Act 
            var result = _validator.Validate(command);

            //Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
