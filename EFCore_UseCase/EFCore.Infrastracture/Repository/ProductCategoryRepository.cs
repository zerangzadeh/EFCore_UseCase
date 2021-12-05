using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Domain.ProductCategoryAgg;
using EFCore.Application.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFCore.Application.Contracts.ProductCategory;
using EFCore.Infrastracture.Repository;



namespace EFCore.Infrastracture.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EFContext efContext;

        public ProductCategoryRepository(EFContext context)
        {
            efContext = context;
        }

        public void Create(ProductCategory productCategory)
        {
           efContext.Add<ProductCategory>(productCategory);
                
           efContext.SaveChanges();
        }

        public void Delete(int CategoryID)
        {
            throw new NotImplementedException();
        }

        public bool Exist(string categoryName)
        {
           return efContext.ProductCategories.Any(x=>x.CategoryName == categoryName);
        }

        public ProductCategory Get(int categoryID)
        {
            return efContext.ProductCategories.FirstOrDefault(x => x.CategoryID == categoryID);
            
        }

        public void SaveChanges()
        {
            efContext.SaveChanges();
        }

       

        public List<ProductCategoryViewModel> Search(string categoryName)
        {
            var query = efContext.ProductCategories.Select(x => new ProductCategoryViewModel
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                CreationDate = x.CreationDate.ToString()
            });

            if (!string.IsNullOrWhiteSpace(categoryName))
                query = query.Where(x => x.CategoryName.Contains(categoryName));
            return query.OrderByDescending(x=>x.CategoryID).ToList();
        }

        public void Update(int categoryID,string categoryName)
        {
            var productCategory=efContext.ProductCategories.FirstOrDefault(x=>x.CategoryID == categoryID);
            productCategory.CategoryName = categoryName;
        }

        public ProductCategory Update(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}
