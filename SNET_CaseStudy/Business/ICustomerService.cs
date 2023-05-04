﻿using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.Business
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult GetById(int customerId);
        List<Customer> GetByFilter(Customer customer);
        IResult Delete(long customerId);
    }
}
