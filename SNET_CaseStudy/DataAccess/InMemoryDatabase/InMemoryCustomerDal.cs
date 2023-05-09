using SNET_CaseStudy.DataAccess.Context;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.DataAccess.InMemoryDatabase
{
    public class InMemoryCustomerDal : ICustomerDal
    {
        List<Customer> _customers;
        public InMemoryCustomerDal()
        {
            _customers = new List<Customer> { };
        }

        public bool Add(Customer customer)
        {
            _customers.Add(customer);
            return true;
        }

        public Customer GetCustomer(long customerTCKN)
        {
            var result = from p in _customers
                         where p.TCKN == customerTCKN
                         select new Customer
                         {
                             Name = p.Name,
                             Surname = p.Surname,
                             TCKN = p.TCKN,
                             BirthDate = p.BirthDate
                         };
            return result.First();
        }

        public List<Customer> GetCustomerListByFilter(Customer customer)
        {

            var result = from p in _customers
                         where p.Name == customer.Name &&
                                p.Surname == customer.Surname &&
                                p.TCKN == customer.TCKN &&
                                p.IsActive == true
                         select new Customer
                         {
                             Name = p.Name,
                             Surname = p.Surname,
                             TCKN = p.TCKN
                         };
            return result.ToList();
        }

        public bool SetCustomerStatusPassive(Customer customer)
        {
            var index = _customers.FindIndex(x => x.TCKN.Equals(customer.TCKN));
            _customers[index].IsActive = false;
            return true;
        }
    }
}
