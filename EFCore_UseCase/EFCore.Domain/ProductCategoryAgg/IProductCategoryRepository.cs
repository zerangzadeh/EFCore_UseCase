using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        ProductCategory Get(int CategoryID);
        void Create(ProductCategory category);
    }
}
