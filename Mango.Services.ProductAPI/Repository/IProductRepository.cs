using Mango.Services.ProductAPI.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Repository
{
    public interface IProductRepository
    {
        #region Methods

        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetProductById(int productId);
        Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
        Task<bool> DeleteProduct(int productId);

        #endregion
    }
}
