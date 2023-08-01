using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoPatternUnitOfWork;
using RepoPatternUnitOfWork.Models;
using RepoPatternUnitOfWork.Repos;

namespace WebApplication3.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class AuthersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        //private readonly IBaseRepo<Auther> authorsRepo;
        public AuthersController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(unitOfWork.authers.GetById(id));

        }
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await unitOfWork.authers.GetByIdAsync(id));

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(unitOfWork.authers.GetAll());
        }
    }
}
