namespace EFCore.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CreationDate { get; set; }
        public double UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public string CategoryName { get; set; }
    }
}
