
using SNET_CaseStudy.DataAccess;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDal _customerDataAccess;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDataAccess = customerDal ?? throw new ArgumentNullException(nameof(customerDal));
        }

        //[ValidationAspect(typeof(ProductValidator))]
        public bool Add(Customer customer)
        {
            return _customerDataAccess.Add(customer);
        }

        public bool Delete(Customer customer)
        {
            return _customerDataAccess.Delete(customer);
        }

        public List<Customer> GetCustomerListByFilter(Customer customer)
        {
            throw new NotImplementedException();
            //return new List<Customer>(_customerDataAccess.GetAll());
        }

        public Customer GetCustomer(Customer customer)
        {
            //ad soyad ve ya tckn filtresi eklenecek
            //_customerDataAccess.GetAll();
            throw new NotImplementedException();
        }
    }
}
