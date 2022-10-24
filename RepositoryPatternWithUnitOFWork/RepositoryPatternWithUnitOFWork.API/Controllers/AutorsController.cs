using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUnitOFWork.Core;
using RepositoryPatternWithUnitOFWork.Core.interfaces;
using RepositoryPatternWithUnitOFWork.Core.models;

namespace RepositoryPatternWithUnitOFWork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorsController : ControllerBase
    {

        //without using unit of work 
        //private readonly IBaseRepository<author> _author;
        //public AutorsController(IBaseRepository<author> author)
        //{
        //    _author = author;
        //}

        //[HttpGet("GetById")]
        //public IActionResult GetById(int id)
        //{
        //    return Ok(_author.GetById(id));
        //}


        //using unit of work
        private readonly IunitOfWork _iunitOfWork;
        public AutorsController(IunitOfWork unitofwork) 
        {
            _iunitOfWork = unitofwork;
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)  
        {
            return Ok(_iunitOfWork.authers .GetById(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_iunitOfWork.authers.GetAll());
        }

        [HttpGet("FindAll")]        
        public IActionResult FindAll()
        {
            return Ok(_iunitOfWork.authers.findAll(n => n.Name == "sanad"));
        }

        [HttpPost("AddAuther")]
        public IActionResult AddAuther()
        {
            return Ok(_iunitOfWork.authers.Add(new author { Id=5, Name="mohamed"}));
        }



    }
}
