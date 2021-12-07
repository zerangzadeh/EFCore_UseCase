using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EFCore.PresentationLayer.Pages.ProductCategory
{
    public class IndexProductCategoryModel : PageModel
    {
        public List<ProductCategoryViewModel> ProductCategories;
        private readonly IProductCategoryApplication productCategoryApplication;

        public IndexProductCategoryModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        

        public void OnGet(string name)
        {
            ProductCategories=productCategoryApplication.Search(name);
        }
    }
}
