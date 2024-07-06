namespace WebApplication1.Models
{
    public class CustomerModel1001
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string PassportNumber { get; set; }

        // Navigation property for bookings
        //public ICollection<BookingModel1001> Bookings { get; set; }

        public CustomerModel1001(int cusId, string name, string address, string mob, int age, string gender, string bloodGrp, string passNo)
        {
            CustomerID = cusId;
            Name = name;
            Address = address;
            Mobile = mob;
            Age = age;
            Gender = gender;
            BloodGroup = bloodGrp;
            PassportNumber = passNo;
        }
    }
}
