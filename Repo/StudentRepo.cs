
using WebApplication1.Models;
namespace WebApplication1.Repo
{
    public interface IStudentRepo
    {
        void AddStudent(StudentModel student);
        List<StudentModel> GetAllStudents();

        List<StudentModel> GetStudentsByLocation(string location);

        List<StudentModel> GetStudentsByBranch(string branch);
    }
    public class StudentRepo : IStudentRepo
    {
        private List<StudentModel> _students;
        public StudentRepo() { 
            this._students = new List<Models.StudentModel>();  
        }
        public void AddStudent(StudentModel s)
        {
            _students.Add(s);
        }

        public List<StudentModel> GetAllStudents()
        {
            return _students;
        }

        public List<StudentModel> GetStudentsByLocation(string location)
        {
            List<StudentModel> li = new List<StudentModel>();
            for(int i = 0; i < _students.Count; i++)
            {
                if (_students[i].Location == location)
                {
                    li.Add(_students[i]);
                }
            }
            return li;
        }

        public List<StudentModel> GetStudentsByBranch(string branch)
        {
            List<StudentModel> li1 = new List<StudentModel>();
            for (int i = 0; i < _students.Count; i++)
            {
                if (_students[i].Branch == branch)
                {
                    li1.Add(_students[i]);
                }
            }
            return li1;
        }
    }
}
