using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = AplicationContext.Books;
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name ="id")]int id)
        {
            var book = AplicationContext.Books.Where(b => b.Id.Equals(id)).SingleOrDefault();
            if(book is null) return NotFound();//404
            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody]Book book)
        {
            try
            {
                if (book is null) return BadRequest();

                AplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name ="id")]int id, [FromBody]Book book)
        {
            //Check book
            var entity=AplicationContext.Books.Find(b=>b.Id.Equals(id));
            
            if (entity is null) return NotFound();//404
            if(id!=book.Id) return BadRequest();//400

            AplicationContext.Books.Remove(entity);
            book.Id=entity.Id;
            AplicationContext.Books.Add(book);
            return Ok(book);//200
        }
    }
}
