using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductCategoryAgg;

namespace EFCore.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
           this.productCategoryRepository = productCategoryRepository;
        }
        
        public void Create(ProductCategoryForCreation command)
        {
            if (!productCategoryRepository.Exist(command.CategoryName))
            {
                productCategoryRepository.Create(new ProductCategory(command.CategoryName));
                productCategoryRepository.SaveChanges();    
            }
        }

        public List<ProductCategoryViewModel> Search(string Name)
        {
            return productCategoryRepository.Search(Name);
        }

        public void Update(ProductCategoryForUpdate command)
        {
           // var productCategory=productCategoryRepository.Get(command.CategoryID);
           // productCategory.Edit(command.CategoryName);
            productCategoryRepository.Update(command.CategoryID, command.CategoryName);
            productCategoryRepository.SaveChanges();

        }
    }
}