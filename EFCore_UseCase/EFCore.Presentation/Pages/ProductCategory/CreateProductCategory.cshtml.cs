using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore.Presentation.Pages.ProductCategory
{
    public class CreateProductCategoryModel : PageModel
    {
        readonly private IProductCategoryApplication productCategoryApplication;

        public CreateProductCategoryModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(ProductCategoryForCreation command)
        {
            productCategoryApplication.Create(command);
            return RedirectToPage("./IndexProductCategory");
            
        }
    }
}
