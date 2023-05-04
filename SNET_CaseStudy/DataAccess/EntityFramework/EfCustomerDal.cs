using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using SNET_CaseStudy.DataAccess.Context;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.DataAccess.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ProjectContext>, ICustomerDal
    {
        //public List<ProductDetailDto> GetProductDetails()
        //{
        //    using (ProjectContext context = new ProjectContext())
        //    {
        //        var result = from p in context.Products
        //                     join c in context.Categories
        //                     on p.CategoryId equals c.CategoryId
        //                     select new ProductDetailDto
        //                     {
        //                         ProductId = p.ProductId,
        //                         ProductName = p.ProductName,
        //                         CategoryName = c.CategoryName,
        //                         UnitsInStock = p.UnitsInStock
        //                     };
        //        return result.ToList();
        //    }
        //}
    }
}