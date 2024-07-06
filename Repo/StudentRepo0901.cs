using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
namespace WebApplication1.Repo
{
    public interface IStudentRepo0901
    {
        void AddStudent(StudentModel0901 s);
        List<StudentModel0901> GetAllStudents();
        List<StudentModel0901> GetStudentWithRollNo(int rollNo);
        List<StudentModel0901> GetAllStudentsByBranch(string branch);
        List<StudentModel0901> GetBloodGrpByRollNo(int rollNo);
        List<StudentModel0901> GetAllStudentsByBloodGrp(string bloodGrp);
        void AddBulkStudents(List<StudentModel0901> students);
        void RemoveStudentByRollNo(int rollNo);
        void UpdateStudentDetails(int rollNo, [FromBody] JsonPatchDocument<StudentModel0901> patchDoc);

    }
    public class StudentRepo0901 : IStudentRepo0901
    {
        private List<StudentModel0901> _students;

        public StudentRepo0901()
        {
            this._students = new List<Models.StudentModel0901>();
        }

        public void AddStudent(StudentModel0901 s)
        {
            _students.Add(s);
        }

        public List<StudentModel0901> GetAllStudents()
        {
            return _students;
        }

        public List<StudentModel0901> GetStudentWithRollNo(int rollNo)
        {
            List<StudentModel0901> li = new List<StudentModel0901>();
            foreach (var student in GetAllStudents())
            {
                if (student.RollNo == rollNo) { li.Add(student); }
            }
            return li;
        }

        public List<StudentModel0901> GetAllStudentsByBranch(string branch)
        {
            List<StudentModel0901> li = new List<StudentModel0901>();
            foreach (var student in GetAllStudents())
            {
                if (student.Branch == branch) { li.Add(student); }
            }
            return li;
        }

        public List<StudentModel0901> GetBloodGrpByRollNo(int rollNo)
        {
            List<StudentModel0901> li = new List<StudentModel0901>();
            foreach (var student in GetAllStudents())
            {
                if(student.RollNo == rollNo) {li.Add(student); }
            }
            return li;
        }

        public List<StudentModel0901> GetAllStudentsByBloodGrp(string bloodGrp)
        {
            List<StudentModel0901> li = new List<StudentModel0901>();
            foreach (var student in GetAllStudents())
            {
                if (student.BloodGrp.Equals(bloodGrp)) { li.Add(student); }
            }
            return li;

        }

        public void AddBulkStudents(List<StudentModel0901> students)
        {
            foreach (var student in students)
            {
                _students.Add(student);
            }
        }

        public void RemoveStudentByRollNo(int rollNo)
        {
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students[i].RollNo == rollNo)
                {
                    _students.Remove(_students[i]);
                }
            }
        }

        public void UpdateStudentDetails(int rollNo, [FromBody] JsonPatchDocument<StudentModel0901> patchDoc)
        {
            foreach (var student in _students) {
                if (student.RollNo == rollNo) {
                    patchDoc.ApplyTo(student);
                }
            }
        }
    }
}


