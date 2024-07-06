using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repo;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController0901 : ControllerBase
    {
        private readonly IStudentRepo0901 _studentRepo0901;

        public StudentController0901(IStudentRepo0901 studentRepo0901 )
        { 
            _studentRepo0901 = studentRepo0901;
        }

        [HttpPost("AddStudent")]
        public IActionResult AddStudent(Models.StudentModel0901 s)
        {
            _studentRepo0901.AddStudent(s);
            return Ok("Success");
        }

        [HttpGet("GetAllStudents")]
        public List<Models.StudentModel0901> GetAllStudents()
        {
           return _studentRepo0901.GetAllStudents();
        }

        [HttpGet("GetStudentWithRollNo")]
        public List<Models.StudentModel0901> GetStudentWithRollNo(int rollNo)
        {
            return _studentRepo0901.GetStudentWithRollNo(rollNo);
        }

        [HttpGet("GetAllStudentsByBranch")]
        public List<Models.StudentModel0901> GetAllStudentsbyBranch(string branch)
        {
            return _studentRepo0901.GetAllStudentsByBranch(branch);
        }

        [HttpGet("GetbloodGrpByRollNo")]
        public List<Models.StudentModel0901> GetBloodGrpByRollNo(int rollNo)
        {
            return _studentRepo0901.GetBloodGrpByRollNo(rollNo);
        }

        [HttpGet("GetAllStudentsByBloodGrp")]
        public List<Models.StudentModel0901> GetAllStudentsByBloodGrp(string bloodGrp) 
        {
                return _studentRepo0901.GetAllStudentsByBloodGrp(bloodGrp);
        }

        [HttpPost("AddBulkStudents")]
        public IActionResult AddBulkStudents(List<Models.StudentModel0901> students)
        {
                _studentRepo0901.AddBulkStudents(students);
            return Ok("success");
        }

        [HttpDelete("RemovestudentByRollNo")]
        public IActionResult RemoveStudentByRollNo(int rollNo)
        {
            _studentRepo0901.RemoveStudentByRollNo(rollNo);
            return Ok("Success");
        }

        [HttpPatch("UpdatestudentDetails")]
        public IActionResult UpdateStudentDetails(int rollNo, [FromBody] JsonPatchDocument<StudentModel0901> patchDoc)
        {
            _studentRepo0901.UpdateStudentDetails(rollNo, patchDoc);
            return Ok("Updated Successfully");
        }
    }
}
