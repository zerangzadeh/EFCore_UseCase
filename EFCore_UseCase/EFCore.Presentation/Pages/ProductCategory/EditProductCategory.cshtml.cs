using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCore.Presentation.Pages.ProductCategory
{
    public class EditProductCategoryModel : PageModel
    {
        readonly private IProductCategoryApplication productCategoryApplication;
        public ProductCategoryForUpdate Command;
        public EditProductCategoryModel(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(int Id)
        {    
            Command = productCategoryApplication.GetDetails(Id); 
                    
        }

        public RedirectToPageResult OnPost(ProductCategoryForUpdate Command)
        {
            productCategoryApplication.Update(Command);
            return RedirectToPage("./IndexProductCategory");
        }
       
    }
}
