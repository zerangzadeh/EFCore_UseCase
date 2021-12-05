namespace EFCore.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public string ProductName { get; set; }
        public string CreationDate { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryID { get; set; }
    }
}
