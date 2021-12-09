using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCore.Presentation.Pages.Product
{
    public class CreateProductModel : PageModel
    {
        List<ProductCategoryViewModel> ProductsCategories;
        public SelectList ProductCategories;
        private readonly IProductCategoryApplication productCategoryApplication;
        private readonly IProductApplication productApplication;

        public CreateProductModel(IProductApplication productApplication,IProductCategoryApplication productCategoryApplication)
        {
            this.productApplication = productApplication;
            this.productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {
            ProductCategories = //new SelectList(ProductCategories);
                new SelectList(productCategoryApplication.GetAll(),
                          "CategoryID", "CategoryName");
        }
        public RedirectToPageResult OnPost(ProductForCreation Command)
        {
            productApplication.Create(Command);
            return RedirectToPage("./IndexProduct");
            
        }
    }
}
