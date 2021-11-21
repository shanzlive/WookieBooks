using FluentAssertions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using WookieBooks.Api.Controllers;
using WookieBooks.Api.Controllers.Requests;
using Xunit;

namespace WookieBooks.Api.Test
{
    public class BookControllerTests
    {
        private readonly Mock<IMediator> _mockMediator = new();
        private const string ValidTitle = "Hamlet";
        private const string ValidDescription = "The play by William Shakespeare";
        private const string ValidAuthor = "William Shakespeare";
        private const string ValidCoverImage = "hamet.jpg";
        private const decimal ValidPrice = 100;
        private readonly AddBookRequest _addBookValidRequest;

        public BookControllerTests()
        {
            _addBookValidRequest = new AddBookRequest
            {
                Author = ValidAuthor,
                CoverImage = ValidCoverImage,
                Description = ValidDescription,
                Price = ValidPrice,
                Title = ValidTitle
            };
            _addBookValidRequest = new AddBookRequest
            {
                Author = string.Empty,
                CoverImage = ValidCoverImage,
                Description = ValidDescription,
                Price = ValidPrice,
                Title = ValidTitle
            };
        }

        [Fact]
        public async Task Create_WithValidRequest_ReturnsAccepted()
        {
            //Arrange
            var controller = new BookController(_mockMediator.Object);

            // Act 
            var actionResult = await controller.PostBook(_addBookValidRequest, CancellationToken.None);

            //Assert
            var result = actionResult as OkObjectResult;
            result.StatusCode.Should().Be(StatusCodes.Status200OK);

        }

    }
}
