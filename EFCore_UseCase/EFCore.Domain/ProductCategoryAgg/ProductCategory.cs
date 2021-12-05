using EFCore.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime  CreationDate { get; set; }
        public List<Product> Products { get; set; }
        public bool IsDeleted { get; set; }

        public ProductCategory(string categoryName)
        {
            CategoryName = categoryName;
            CreationDate = DateTime.Now;
            Products = new List<Product>(); 
        }

        public void Edit(string categoryName)
        {
            CategoryName = categoryName;
        }

    }
}
