using LibraryApi.Dto.Author;
using LibraryApi.Models;
using LibraryApi.Services.Author;
using Microsoft.AspNetCore.Mvc;

// Como funciona a comunicação
// A controller se comunica com a Interface (IAuthorInterface)
// E a interface se comunica com a Service (AuthorService)

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet("GetAuthors")]
        [ProducesResponseType(typeof(ResponseModel<List<AuthorModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAuthors([FromServices] IAuthorInterface _authorInterface)
        // ActionResult é basicamente para retornarmos o status code
        {
            var authors = await _authorInterface.GetAuthors();
            return Ok(authors);
            // Retornamos Ok, que todos os dados foram coletados, autores
        }

        [HttpGet("GetAuthorById/{idAuthor}")]
        [ProducesResponseType(typeof(ResponseModel<AuthorModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorById(int idAuthor, [FromServices] IAuthorInterface _authorInterface)
        {
            var authors = await _authorInterface.GetAuthorById(idAuthor);
            return Ok(authors);
        }

        [HttpGet("GetAuthorByBookId/{idBook}")]
        [ProducesResponseType(typeof(ResponseModel<AuthorModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<AuthorModel>>> GetAuthorByBookId(int idBook, [FromServices] IAuthorInterface _authorInterface)
        {
            var author = await _authorInterface.GetAuthorByBookId(idBook);
            return Ok(author);
        }

        [HttpPost("CreateAuthor")]
        [ProducesResponseType(typeof(ResponseModel<List<AuthorModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> CreateAuthor(AuthorCreateDto authorCreateDto, [FromServices] IAuthorInterface _authorInterface)
        {
            var authors = await _authorInterface.CreateAuthor(authorCreateDto);
            return Ok(authors);
        }
        
        [HttpPut("EditAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> EditAuthor(AuthorEditDto authorEditDto, [FromServices] IAuthorInterface _authorInterface)
        {
            var authors = await _authorInterface.EditAuthor(authorEditDto);
            return Ok(authors);
        }        
        
        [HttpDelete("DeleteAuthor")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> DeleteAuthor(int idAuthor, [FromServices] IAuthorInterface _authorInterface)
        {
            var authors = await _authorInterface.DeleteAuthor(idAuthor);
            return Ok(authors);
        }
    }
}
