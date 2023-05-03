using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDataAccess _customerDataAccess;
        private readonly ICustomerService _customerService;
        public IResult Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(long customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetByFilter()
        {
            throw new NotImplementedException();
        }

        public IResult GetById(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
