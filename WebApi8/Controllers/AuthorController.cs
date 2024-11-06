using LibraryApi.Models;
using LibraryApi.Services.Author;
using Microsoft.AspNetCore.Http;
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
        private readonly IAuthorInterface _authorInterface;
        public AuthorController(IAuthorInterface authorInterface)
        {
            _authorInterface = authorInterface;
        }

        [HttpGet("GetAuthors")]
        public async Task<ActionResult<ResponseModel<List<AuthorModel>>>> GetAuthors()
        // ActionResult é basicamente para retornarmos o status code
        {
            var authors = await _authorInterface.GetAuthors();
            return Ok(authors);
            // Retornamos Ok, que todos os dados foram coletados, autores
        }

    }
}
