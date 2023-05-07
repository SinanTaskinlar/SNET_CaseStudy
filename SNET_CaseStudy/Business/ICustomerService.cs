using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.Business
{
    public interface ICustomerService
    {
        bool Add(Customer customer);
        Customer GetCustomer(Customer customer);
        List<Customer> GetCustomerListByFilter(Customer customer);
        bool Delete(Customer customer);
    }
}