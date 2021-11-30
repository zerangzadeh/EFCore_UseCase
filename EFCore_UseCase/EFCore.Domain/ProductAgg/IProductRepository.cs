using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductAgg
{
    public interface IProductRepository
    {

        Product Get(int ProductID);
        void Create(Product product);


    }
}
