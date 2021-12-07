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
        public double UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryID { get; set; }
        public ProductCategory ProductCategory { get; set; }




        public Product(string productName, DateTime creationDate, double unitPrice, int categoryID)
        {
            ProductName = productName;
            CreationDate = creationDate;
            UnitPrice = unitPrice;
            CategoryID = categoryID;
        }
        //public void Edit(string productName, DateTime addDate, double unitPrice, int categoryID)
        //{
        //    ProductName = productName;
        //    CreationDate = addDate;
        //    UnitPrice = unitPrice;
        //    CategoryID = categoryID;

        //}
        //public void Remove()
        //{
        //    IsDeleted = true;   
        //}
        //public void Restore()
        //{
        //   IsDeleted=false;
        //}

    }
}
