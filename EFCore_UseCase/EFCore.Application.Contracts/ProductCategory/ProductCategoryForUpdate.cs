namespace EFCore.Application.Contracts.ProductCategory
{
    public class ProductCategoryForUpdate:ProductCategoryForCreation
    {
        public int CategoryID { get; set; }
    }
}
