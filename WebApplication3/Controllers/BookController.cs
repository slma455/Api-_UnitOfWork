using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternUnitOfWork;
using RepoPatternUnitOfWork.Models;
using RepoPatternUnitOfWork.Repos;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        //private readonly IBaseRepo<Book> booksRepo;
        public BookController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(unitOfWork.books.GetById(id));

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(unitOfWork.books.GetAll());
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName(string name )
        {
            return Ok(unitOfWork.books.Find(b => b.Title == name));
        }
        [HttpGet("GetAll")]
        public IActionResult GetAllWithAuthers()
        {
            return Ok(unitOfWork.books.FindAll(b => b.Title == "", new[] { "Authers" }));
        }
        [HttpGet("GetOrderd")]
        public IActionResult GetOrderd()
        {
            return Ok(unitOfWork.books.FindAll(b => b.Title == "", null , null , b => b.Id));
        }
        [HttpPost("AddOne")]
        public IActionResult AddOne()
        {
            var book = unitOfWork.books.Add(new Book { Title = " Test", AutherId = 1 });
            unitOfWork.Complete();
            return Ok(book);
        }
    }
}
