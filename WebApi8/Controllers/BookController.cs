using LibraryApi.Models;
using LibraryApi.Services.Book;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        [HttpGet("GetBooks")]
        [ProducesResponseType(typeof(ResponseModel<List<BookModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetAuthors([FromServices] IBookInterface _bookInterface)
        // ActionResult é basicamente para retornarmos o status code
        {
            var books = await _bookInterface.GetBooks();
            return Ok(books);
            // Retornamos Ok, que todos os dados foram coletados, autores
        }
        
        [HttpGet("GetBookById")]
        [ProducesResponseType(typeof(ResponseModel<BookModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<BookModel>>> GetBookById([FromServices] IBookInterface _bookInterface, [FromQuery] int id)
        {
            var book = await _bookInterface.GetBookById(id);
            return Ok(book);
        }
        
        [HttpGet("GetBooksByAuthorId")]
        [ProducesResponseType(typeof(ResponseModel<List<BookModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<List<BookModel>>>> GetBooksByAuthorId([FromServices] IBookInterface _bookInterface, [FromQuery] int id)
        {
            var books = await _bookInterface.GetBooksByAuthorId(id);
            return Ok(books);
        }
    }
}
