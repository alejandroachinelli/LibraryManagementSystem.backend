using LibraryManagementSystem.Application.Features.Book.Commands.AddBookCommand;
using LibraryManagementSystem.Application.Features.Book.Commands.DeleteBookCommand;
using LibraryManagementSystem.Application.Features.Book.Commands.LendBookCommand;
using LibraryManagementSystem.Application.Features.Book.Commands.ReturnAllBookCommand;
using LibraryManagementSystem.Application.Features.Book.Commands.ReturnBookCommand;
using LibraryManagementSystem.Application.Features.Book.Queries.GetAllBookQuery;
using LibraryManagementSystem.Application.Features.Book.Queries.GetAllLendBookQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryManagementSystem.Application.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;

        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetAllBooks")]
        [EndpointSummary("Obtiene todos los libros disponibles en la biblioteca.")]
        public async Task<IActionResult> GetAllBook([FromRoute] GetAllBookQuery query)
        {
            var response = await mediator.Send(query);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet("GetAllLoanedBooks")]
        [EndpointSummary("Obtiene todos los libros que estan prestados.")]
        public async Task<IActionResult> GetAllLoanedBook([FromRoute] GetAllLendBookQuery query)
        {
            var response = await mediator.Send(query);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPost("InsertBook")]
        [EndpointSummary("Agrega un nuevo libro a la biblioteca.")]
        public async Task<IActionResult> AddBook([FromBody] AddBookCommand command)
        {
            var response = await mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpDelete("DeleteBook/{id}")]
        [EndpointSummary("Elimina un libro de la biblioteca.")]
        public async Task<IActionResult> DeleteBook([FromRoute] string id)
        {
            var response = await mediator.Send(new DeleteBookCommand(new Guid(id)));

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("LendBook")]
        [EndpointSummary("Realiza el prestamo de un libro.")]
        public async Task<IActionResult> LendBook([FromBody] LendBookCommand command)
        {
            var response = await mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("ReturnAllBook")]
        [EndpointSummary("Realiza la devolucion de todos los libros prestados.")]
        public async Task<IActionResult> ReturnAllBook([FromBody] ReturnAllBookCommand command)
        {
            var response = await mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut("ReturnBook")]
        [EndpointSummary("Realiza la devolucion de un libro prestado.")]
        public async Task<IActionResult> ReturnBook([FromBody] ReturnBookCommand command)
        {
            var response = await mediator.Send(command);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
