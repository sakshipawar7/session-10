namespace WebApplication1.Models
{
    public class StudentModel0901
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Branch { get; set; }
        public double Marks { get; set; }
        public string Location { get; set; }
        public string Mobile { get; set; }
        public string BloodGrp { get; set; }

        public StudentModel0901(string name, int rollNo, string branch, double marks, string location , string mobile, string bloodGrp)
        {
            Name = name;
            RollNo = rollNo;
            Branch = branch;
            Marks = marks;
            Location = location;
            Mobile = mobile;
            BloodGrp = bloodGrp;
        }
    }
}
