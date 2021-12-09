using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Infrastracture.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFContext efContext;

        public ProductRepository(EFContext efContext)
        {
            this.efContext = efContext;
        }

        public void Create(Product product)
        {
           efContext.Products.Add(product);
        }

        public bool Exist(string name, int categoryId)
        {
            return efContext.Products.Any(x=>x.ProductName==name && x.CategoryID==categoryId);
        }

        public Product Get(int ProductID)
        {
            return efContext.Products.FirstOrDefault(x=>x.ProductID == ProductID);
        }

        public ProductForUpdate GetDetails(int id)
        {
            return efContext.Products.Select(x=>new ProductForUpdate {
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                CategoryID = x.CategoryID,
              }).FirstOrDefault(x => x.ProductID == id);
        }

        public void Remove(int ProductID)
        {
            efContext.Products.FirstOrDefault(x=>x.ProductID==ProductID).IsDeleted=true;
        }

        public void Restore(int ProductID)
        {
            efContext.Products.FirstOrDefault(x => x.ProductID == ProductID).IsDeleted = false;
        }

        public void SaveChanges()
        {
            efContext.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = efContext.Products.Include(x => x.ProductCategory).Select(x => new ProductViewModel {
                ProductId = x.ProductID,
                ProductName = x.ProductName,
                UnitPrice = x.UnitPrice,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(),
                CategoryName = x.ProductCategory.CategoryName
            });
             if (searchModel.IsDeleted==true)
            {
                query=query.Where(x => x.IsDeleted == true);
            }
             if (!string.IsNullOrWhiteSpace(searchModel.ProductName))
                query=query.Where(x=>x.ProductName.Contains(searchModel.ProductName));
             return query.OrderByDescending(x=>x.ProductId).AsNoTracking().ToList();
        }

        public void Update(int ProductId,string ProductName,double UnitPrice,int CategoryID)
        {
            var product=efContext.Products.FirstOrDefault(x => x.ProductID == ProductId);
            
            product.UnitPrice = UnitPrice;
            product.CategoryID = CategoryID;
            product.ProductName = ProductName;
                        
        }
    }
}
