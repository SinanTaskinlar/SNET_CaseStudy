using DataAccess.Abstract;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal _customerDataAccess;
        private readonly ICustomerService _customerService;

        public CustomerService(ICustomerDal productDal, ICustomerService categoryService)
        {
            _customerDataAccess = productDal ?? throw new ArgumentNullException(nameof(productDal));
            _customerService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        //[ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(long customerId)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetByFilter(Customer customer)
        {
            throw new NotImplementedException();
            //return new List<Customer>(_customerDataAccess.GetAll());
        }

        public IResult GetById(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
