using LMS.API.Filters;
using LMS.DataBase.Entities;
using LMS.Services.DTO;
using LMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookServices _bookServices;
        public BookController(IBookServices bookServices)
        {
            _bookServices = bookServices;
        }
        [TypeFilter(typeof(ExceptionFilter))]
        [HttpGet("ViewBooks")]
        public IActionResult ViewBook([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            return Ok(_bookServices.GetBook(pageNumber, pageSize));
        }
        [TypeFilter(typeof(ExceptionFilter))]
        [HttpPost("AddBook")]
        public IActionResult CreateBook(BookDTO book)
        {
            _bookServices.AddBook(book);
            return Ok("Book added");
        }
        [TypeFilter(typeof(ExceptionFilter))]
        [HttpPost("Update")]
        public IActionResult UpdateBook(int id, BookDTO book)
        {
            _bookServices.Update(id, book);
            return Ok("Updated Successfully");
        }
        [TypeFilter(typeof(ExceptionFilter))]
        [HttpDelete("Delete")]
        public IActionResult DeleteBook(int id)
        {
            _bookServices.Delete(id);
            return Ok("Deleted successfully");
        }
        [TypeFilter(typeof(ExceptionFilter))]
        [HttpGet("Search")]
        public List<Book> SearchBook([FromQuery] SearchDTO book)
        {
            return _bookServices.Search(book);
        }
        [TypeFilter(typeof(ExceptionFilter))]
        [HttpGet("Sort")]
        public List<Book> SortBook([FromQuery] SortDTO book, int pageNumber, int pageSize)
        {
            return _bookServices.Sort(book, pageNumber, pageSize);
        }


    }
}
