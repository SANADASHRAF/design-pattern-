using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOFWork.Core;
using RepositoryPatternWithUnitOFWork.Core.interfaces;
using RepositoryPatternWithUnitOFWork.Core.models;

namespace RepositoryPatternWithUnitOFWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //with out using unit of work 
        //private readonly IBaseRepository<books> _book;

        //public BookController(IBaseRepository<books> book)
        //{
        //    _book = book;
        //}


        private readonly IunitOfWork _unitOfWork;
        public BookController(IunitOfWork iunitOfWork)
        {
            _unitOfWork = iunitOfWork;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.books .GetById(id));
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.books.GetAll());
        }


        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.books.find(n=>n.titel=="c++"));
        }

        //include
        [HttpGet("GetByInclude")]
        public IActionResult GetByInclude()
        {
            return Ok(_unitOfWork.books.find(n => n.titel == "c++", new[] {"author"} ));
        }


        [HttpGet("FindAllInclude")]
        public IActionResult FindAllInclude()
        {
            return Ok(_unitOfWork.books.find(n => n.titel.Contains ( "c++"), new[] { "author" }));
        }

        [HttpGet("FindAll")]
        public IActionResult FindAll()
        {
            return Ok(_unitOfWork.books.findAll(n => n.authorid == 1));
        }

        [HttpPost("Addbook")]
        public IActionResult Addbook()
        {
            var quary=(_unitOfWork.books.Add(new books { id=4, titel="fuction", authorid=2}));
            _unitOfWork.complete();
            return Ok(quary);
        
        }
    }
}
