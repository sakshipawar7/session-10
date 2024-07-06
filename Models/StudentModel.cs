namespace WebApplication1.Models
{
    public class StudentModel
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Branch { get; set; }
        public double Marks { get; set; }
        public string Location { get; set; }

        public StudentModel(string name, int rollNo, string branch, double marks, string location)
        {
            Name = name;
            RollNo = rollNo;
            Branch = branch;
            Marks = marks;
            Location = location;
        }
    }
}
