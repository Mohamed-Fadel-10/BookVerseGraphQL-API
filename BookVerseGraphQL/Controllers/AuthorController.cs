using BookVerseGraphQL.Data;
using BookVerseGraphQL.GraphQL.Mutation;
using BookVerseGraphQL.GraphQL.Types;
using BookVerseGraphQL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookVerseGraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly Context _context;
        public AuthorController(Context context) { 
        _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorType author)
        {
            await _context.Authors.AddAsync(new Models.Author
            {
                Name= author.Name,
            });
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            return Ok(await _context.Authors.ToListAsync());

        }
    }
}
