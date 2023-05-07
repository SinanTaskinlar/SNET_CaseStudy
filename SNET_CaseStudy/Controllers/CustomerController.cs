using Microsoft.AspNetCore.Mvc;
using SNET_CaseStudy.Business;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpPost(Name = "AddCustomer")]
        public bool AddCustomer(Customer customer)
        {
            return _customerService.Add(customer);
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public bool DeleteCustomer(long customerTCKN)
        {
            return _customerService.Delete(new Customer { TCKN = customerTCKN});
        }

        [HttpGet(Name = "GetCustomer")]
        public Customer GetCustomer(long customerTCKN)
        {
            return _customerService.GetCustomer(new Customer { TCKN = customerTCKN});
        }

        [HttpGet(Name = "GetCustomerListByFilter")]
        public IEnumerable<Customer> GetCustomerListByFilter(Customer customer)
        {
            return _customerService.GetCustomerListByFilter(customer);
        }
    }
}