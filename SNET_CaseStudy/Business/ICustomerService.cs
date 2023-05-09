using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.Business
{
    public interface ICustomerService
    {
        bool Add(CustomerDto customer);
        CustomerDto GetCustomer(string customerTCKN);
        List<CustomerDto> GetCustomerListByFilter(CustomerDto customer);
        bool SetCustomerStatusPassive(string customerTCKN);
    }
}