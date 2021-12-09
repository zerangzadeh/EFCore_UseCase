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
            Products=productApplication.Search(productSearchModel);
        }
    }
}
