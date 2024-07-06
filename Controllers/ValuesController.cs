using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repo;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class ValuesController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        public ValuesController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Models.StudentModel student)
        {
            _studentRepo.AddStudent(student);
            return Ok("Success");
        }

        [HttpGet("GetAllStudents")]
        public List<Models.StudentModel> GetAllStudents()
        {
           return _studentRepo.GetAllStudents();
        }

        [HttpGet("GetStudentsByLocation")]
        public List<Models.StudentModel> GetStudentsByLocation(string location)
        {
            return _studentRepo.GetStudentsByLocation(location);
        }

        [HttpGet("GetStudentsByBranch")]
        public List<Models.StudentModel> GetStudentsByBranch(string branch)
        {
            return _studentRepo.GetStudentsByBranch(branch);
        }
    } 
}
