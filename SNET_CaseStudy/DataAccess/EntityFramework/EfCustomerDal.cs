﻿
using Microsoft.EntityFrameworkCore;
using SNET_CaseStudy.DataAccess.Context;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.DataAccess.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        public Customer GetCustomer(long customerTCKN)
        {
            using ProjectContext context = new();
            var result = from p in context.Customers
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
            using ProjectContext context = new();
            var result = from p in context.Customers
                         where p.Name == customer.Name &&
                                p.Surname == customer.Surname &&
                                p.TCKN == customer.TCKN
                         select new Customer
                         {
                             Name = p.Name,
                             Surname = p.Surname,
                             TCKN = p.TCKN
                         };
            return result.ToList();
        }

        bool ICustomerDal.Add(Customer customer)
        {
            using ProjectContext context = new();
            var addedEntity = context.Entry(customer);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
            return true;
        }

        bool ICustomerDal.SetCustomerStatusPassive(Customer customer)
        {
            using ProjectContext context = new();
            var updatedEntity = context.Entry(customer);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }
    }
}