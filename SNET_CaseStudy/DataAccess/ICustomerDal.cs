using SNET_CaseStudy.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SNET_CaseStudy.DataAccess
{
    public interface ICustomerDal
    {
        bool Add(Customer customer);
        Customer GetCustomer(Customer customer);
        List<Customer> GetCustomerListByFilter(Customer customer);
        bool Delete(Customer customer);
    }
}
