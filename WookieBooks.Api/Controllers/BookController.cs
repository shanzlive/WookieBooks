using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WookieBooks.Api.Controllers.Requests;
using WookieBooks.Application.Commands.AddBook;
using WookieBooks.Application.Commands.DeleteBook;
using WookieBooks.Application.Commands.UpdateBook;
using WookieBooks.Application.Queries;
using WookieBooks.Domain.Models;


namespace WookieBooks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator ;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<BookController>/GetBooks
        /// <summary>
        /// Get all books
        /// </summary>
        /// <response code="200">Returns complete list of books</response>
        [HttpGet("GetBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            
            var result = await _mediator.Send(new GetBooksAllQuery());
            return Ok(result);
        }

        // GET api/<BookController>/GetBookByAuthorOrTitle
        /// <summary>
        /// Get list of books based on the filter value passed
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Returns list of books based on the filter value passed</response>
        /// <response code="404">No Books found for the filter criteria</response>
        [HttpGet("GetBookByAuthorOrTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Book>>> GetBookByAuthorOrTitle(string title, string author, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetBooksByTitleOrAuthorQuery(title, author));
            if(result.Count.Equals(0))
            {
               return NotFound("No records found!");
            }
            return Ok(result);
        }

        // POST api/<BookController>
        /// <summary>
        /// Update a book data based on id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Book added successfully</response>
        /// <response code="409">Book already exist with same Author and title</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> PostBook([FromBody] AddBookRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddBookCommand(request.Title, request.Description, request.Author, request.CoverImage, request.Price), cancellationToken);
            return Ok("Book added successfully");
        }
        /// <summary>
        /// Update book details
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="204">Book updated successfully</response>
        /// <response code="404">No Books found with the id</response>
        // PUT api/<BookController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateBookCommand(request.Id, request.Title, request.Description, request.Author, request.CoverImage, request.Price), cancellationToken);
            return NoContent();
        }

        /// <summary>
        /// Delete book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="204">Book deleted</response>
        /// <response code="404">No Books found with the id</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBook(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteBookCommand(id), cancellationToken);
            return NoContent();
        }
    }
}
