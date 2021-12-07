using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Application.Contracts.Product
{
    public interface IProductApplication
    {
        public void Create(ProductForCreate command);
        public void Update(ProductForUpdate command);
        public ProductForUpdate GetDetails(int id);
        List<ProductViewModel> Search(ProductSearchModel productSearchModel);
        public void Delete(int id);
        public void Restore(int id);

    }
}
