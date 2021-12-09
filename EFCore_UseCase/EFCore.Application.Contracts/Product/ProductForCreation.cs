using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Application.Contracts.Product
{
    public class ProductForCreation
    {
      
        public string ProductName { get; set; }
        public DateTime CreationDate { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryID { get; set; }
      
    }
}
