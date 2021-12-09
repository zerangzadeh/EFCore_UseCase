using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;
using EFCore.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Create(ProductForCreation command)
        {
            if (!productRepository.Exist(command.ProductName, command.CategoryID))
            {
                productRepository.Create(new Product(command.ProductName, command.CreationDate, command.UnitPrice, command.CategoryID));
                productRepository.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var product = productRepository.Get(id);
            if (product != null)
            productRepository.Remove(id);
            productRepository.SaveChanges();
        }

        public ProductForUpdate GetDetails(int id)
        {
            return productRepository.GetDetails(id);
        }

        public void Restore(int id)
        {
            var product = productRepository.Get(id);
            if (product != null)
                productRepository.Restore(id);
            productRepository.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel productSearchModel)
        {
           return productRepository.Search(productSearchModel);
        }

        public void Update(ProductForUpdate command)
        {
            var product = productRepository.Get(command.ProductID);
            if (product != null)    
            productRepository.Update(command.ProductID,command.ProductName, command.UnitPrice, command.CategoryID);
             productRepository.SaveChanges();
        }

       
    }
}
