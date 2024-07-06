using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repo;
using Microsoft.AspNetCore.JsonPatch;

namespace WebApplication1.Controllers
{
    [Route("Customer")]
    [ApiController]
    public class CustomerController1001 : ControllerBase
    {
        private readonly ICustomerRepo1001 _customerRepo;
        private readonly IBookingRepo1001 _bookingRepo;

        public CustomerController1001(ICustomerRepo1001 customerRepo, IBookingRepo1001 bookingRepo)
        {
            _customerRepo = customerRepo;
            _bookingRepo = bookingRepo;
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer(CustomerModel1001 customer)
        {
            _customerRepo.AddCustomer(customer);
            return Ok("Success");
        }

        [HttpPost("AddBulkCustomers")]
        public IActionResult AddBulkCustomers(List<CustomerModel1001> customers)
        {
            _customerRepo.AddBulkCustomers(customers);
            return Ok("Success");
        }

        [HttpGet("GetAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            List<CustomerModel1001> c = _customerRepo.GetAllCustomers();
            return Ok(c);
        }

        [HttpGet("GetCustomerByID")]
        public IActionResult GetCustomerByID(int customerID)
        {
            CustomerModel1001 i = _customerRepo.GetCustomerByID(customerID);
            return Ok(i);
        }

        [HttpGet("GetCustomersByBloodGroup")]
        public IActionResult GetCustomersByBloodGroup(string bloodGroup)
        {
            List<CustomerModel1001> c = _customerRepo.GetCustomersByBloodGroup(bloodGroup);
            return Ok(c);
        }

        [HttpDelete("RemoveCustomerById")]
        public IActionResult RemoveCustomerById(List<BookingModel1001> b, int customerID)
        {
            _customerRepo.RemoveCustomerById(_bookingRepo.GetAllBookings(), customerID);
            return Ok("Success");
        }

        [HttpPatch("UpdateCustomer")]
        public IActionResult UpdateCustomer(int customerID, JsonPatchDocument<CustomerModel1001> patch)
        {
            _customerRepo.UpdateCustomer(customerID, patch);
            return Ok("Success");
        }
    }
}
