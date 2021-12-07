using EFCore.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Domain.ProductAgg
{
    public interface IProductRepository
    {
        Product Get(int productID);
        void Create(Product product);
        void Remove(int productID);
        void Restore(int productID);
        void Update(int productId, string productName, double unitPrice, int categoryID);
        ProductForUpdate GetDetails(int id);
        bool Exist(string name, int categoryId);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        void SaveChanges();

    }
}
