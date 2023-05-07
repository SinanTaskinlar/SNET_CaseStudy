
using Microsoft.EntityFrameworkCore;
using SNET_CaseStudy.DataAccess.Context;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.DataAccess.EntityFramework
{
    public class EfCustomerDal : ICustomerDal
    {
        public Customer GetCustomer(Customer customer)
        {
            using ProjectContext context = new();
            var result = from p in context.Customers
                         select new Customer
                         {
                             TCKN = p.TCKN
                         };
            return result.First();
        }

        public List<Customer> GetCustomerListByFilter(Customer customer)
        {
            using ProjectContext context = new();
            var result = from p in context.Customers
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

        bool ICustomerDal.Delete(Customer customer)
        {
            using ProjectContext context = new();
            var deletedEntity = context.Entry(customer);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
            return true;
        }
    }
}