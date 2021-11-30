using EFCore.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EFCore.Domain.ProductAgg
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryID { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public Product(string productName, DateTime addDate, decimal unitPrice, int categoryID)
        {
            ProductName = productName;
            CreationDate = addDate;
            UnitPrice = unitPrice;
            CategoryID = categoryID;
        }
    }
}
