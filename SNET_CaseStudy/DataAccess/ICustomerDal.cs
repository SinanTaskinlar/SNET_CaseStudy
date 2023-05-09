using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.DataAccess
{
    public interface ICustomerDal
    {
        bool Add(Customer customer);
        Customer GetCustomer(long customerTCKN);
        List<Customer> GetCustomerListByFilter(Customer customer);
        bool SetCustomerStatusPassive(Customer customer);
    }
}
