using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(ProductCategoryForCreation command);
        void Update(ProductCategoryForUpdate command);
        ProductCategoryForUpdate GetDetails(int id);
        List<ProductCategoryViewModel> Search(string name);
        List<ProductCategoryViewModel> GetAll();


    }
}
