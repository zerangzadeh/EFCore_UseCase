using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore.Presentation.Pages.Product
{
    public class EditProductModel : PageModel
    {
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication productCategoryApplication;
        public SelectList ProductCategories;
        public ProductForUpdate Command;
        public EditProductModel(IProductApplication productApplication,IProductCategoryApplication productCategoryApplication)
        {
            this.productApplication = productApplication;
            this.productCategoryApplication = productCategoryApplication;   
        }

        public void OnGet(int Id)
        {
            ProductCategories = new SelectList(productCategoryApplication.GetAll(), "CategoryID", "CategoryName");
            Command = productApplication.GetDetails(Id); 
                    
        }

        public RedirectToPageResult OnPost(ProductForUpdate Command)
        {
            productApplication.Update(Command);
            return RedirectToPage("./IndexProduct");
        }
       
    }
}
