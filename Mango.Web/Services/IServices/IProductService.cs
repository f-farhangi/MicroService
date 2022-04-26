using Mango.Web.Models.Dtos;
using System.Threading.Tasks;

namespace Mango.Web.Services.IServices
{
    public interface IProductService : IBaseService
    {
        #region Methods

        Task<T> GetAllProductsAsync<T>();
        Task<T> GetProductByIdAsync<T>(int productId);
        Task<T> CreateProductAsync<T>(ProductDto productDto);
        Task<T> UpdateProductAsync<T>(ProductDto productDto);
        Task<T> DeleteProductsAsync<T>(int productId);

        #endregion
    }
}
