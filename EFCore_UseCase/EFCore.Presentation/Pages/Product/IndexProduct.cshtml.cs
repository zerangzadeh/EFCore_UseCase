using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EFCore.Presentation.Pages.Product
{
    public class IndexProductModel : PageModel
    {
        public List<ProductViewModel> Products;
        private readonly IProductApplication productApplication;

        public IndexProductModel(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
        }



        public void OnGet(ProductSearchModel productSearchModel)
        {
            Products = productApplication.Search(productSearchModel);
        }


        public RedirectToPageResult OnGetDelete(int id)
        {

            productApplication.Delete(id);
            return RedirectToPage("./IndexProduct");
        }


        public RedirectToPageResult OnGetRestore(int id)
        {
            productApplication.Restore(id);
            return RedirectToPage("./IndexProduct");
        }


    }
}
