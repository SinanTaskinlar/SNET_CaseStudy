using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SNET_CaseStudy.Business;
using SNET_CaseStudy.Entities;
using SNET_CaseStudy.Validation;

namespace SNET_CaseStudy.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger _logger;

        public CustomerController(ICustomerService customerService, ILogger<Customer> logger)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _logger = logger;
            
        }

        [HttpPost(Name = "AddCustomer")]
        public ActionResult<bool> AddCustomer(CustomerDto customer)
        {
            CustomerValidator.ValidateCustomer(customer);
            _logger.LogInformation("Customer Validated at {DT}", DateTime.UtcNow.ToLongTimeString());
            return Ok(_customerService.Add(customer));
        }

        [HttpPatch(Name = "SetCustomerStatusPassive")]
        public ActionResult<bool> SetCustomerStatusPassive(string customerTCKN)
        {
            CustomerValidator.ValidateTcknLength(customerTCKN);

            return Ok(_customerService.SetCustomerStatusPassive(customerTCKN));
        }

        [HttpGet(Name = "GetCustomer")]
        public ActionResult<CustomerDto> GetCustomer(string customerTCKN)
        {
            CustomerValidator.ValidateTcknLength(customerTCKN);

            return Ok(_customerService.GetCustomer(customerTCKN));
        }

        [HttpGet(Name = "GetCustomerListByFilter")]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomerListByFilter(CustomerDto customer)
        {
            return Ok(_customerService.GetCustomerListByFilter(customer));
        }
    }
}