using EFCore.Application.Contracts.ProductCategory;
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
        void Delete(int categoryID);
        public List<ProductCategoryViewModel> Search(string categoryName);
        bool Exist(string categoryName); 
        void Update(int categoryID,string categoryName);
        ProductCategoryForUpdate GetDetails(int categoryID);
        void SaveChanges();


    }
}
