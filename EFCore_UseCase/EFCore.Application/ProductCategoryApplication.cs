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

        public ProductCategoryForUpdate GetDetails(int id)
        {
            return productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(string Name)
        {
            return productCategoryRepository.Search(Name);
        }

        public void Update(ProductCategoryForUpdate command)
        {
           //command=ProductCategoryApplication.GetDetails()
            productCategoryRepository.Update(command.CategoryID, command.CategoryName);
            productCategoryRepository.SaveChanges();

        }
    }
}