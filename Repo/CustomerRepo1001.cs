using WebApplication1.Models;
using Microsoft.AspNetCore.JsonPatch;
namespace WebApplication1.Repo
{
    public interface ICustomerRepo1001
    {
        void AddCustomer(CustomerModel1001 customer);
        void AddBulkCustomers(List<CustomerModel1001> customers);
        List<CustomerModel1001> GetAllCustomers();
        CustomerModel1001 GetCustomerByID(int customerID);
        List<CustomerModel1001> GetCustomersByBloodGroup(string bloodGroup);
        void RemoveCustomerById(List<BookingModel1001> b, int customerID);
        void UpdateCustomer(int customerID, JsonPatchDocument<CustomerModel1001>  patch);
    }
    public class CustomerRepo1001 : ICustomerRepo1001
    {
        private List<CustomerModel1001> _customers;

        public CustomerRepo1001()
        {
            _customers = new List<CustomerModel1001>();
        }

        public void AddCustomer(CustomerModel1001 customer)
        {
            customer.CustomerID = _customers.Count + 1;
            _customers.Add(customer);
        }

        public void AddBulkCustomers(List<CustomerModel1001> customers)
        {
            for(int i = 0; i < customers.Count; i++)
            {
                customers[i].CustomerID = _customers.Count + 1;
                _customers.Add(_customers[i]);
            }
        }

        public List<CustomerModel1001> GetAllCustomers()
        {
            return _customers;
        }

        public CustomerModel1001 GetCustomerByID(int customerID)
        {
            foreach(var  customer in _customers)
            {
                if(customer.CustomerID == customerID) return customer;
            }
            return null;
        }

        public List<CustomerModel1001> GetCustomersByBloodGroup(string bloodGroup)
        {
            List<CustomerModel1001> c = new List<CustomerModel1001>();
            foreach (var customer in _customers)
            {
                if(customer.BloodGroup.Equals(bloodGroup)) c.Add(customer);
            }
            return c;
        }

        public void RemoveCustomerById(List<BookingModel1001> b, int customerID)
        {
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i].CustomerID == customerID)
                {
                    b.Remove(b[i]);
                }
            }
            for (int i = 0; i < _customers.Count; i++)
            {
                if(_customers[i].CustomerID == customerID)
                {
                    _customers.Remove(_customers[i]);
                    break;
                }
            }
        }

        public void UpdateCustomer(int customerID, JsonPatchDocument<CustomerModel1001> patch)
        {
            for(int i = 0; i < _customers.Count;i++)
            {
                if (_customers[i].CustomerID == customerID)
                {
                    patch.ApplyTo(_customers[i]);
                    return;
                }
            }
        }
    }
}
