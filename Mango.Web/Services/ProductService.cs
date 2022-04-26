using Mango.Web.Models.Dtos;
using Mango.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mango.Web.Services
{
    public class ProductService : BaseService, IProductService
    {
        #region Fields

        private readonly IHttpClientFactory _httpClient;

        #endregion

        #region Constructor

        public ProductService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<T> CreateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                AccessToken = null,
                ApiType = SD.ApiType.Post,
                Data = productDto,
                Url = SD.ProductAPIBase + "api/Products"
            });
        }

        public async Task<T> DeleteProductsAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                AccessToken = null,
                ApiType = SD.ApiType.Delete,
                Data = null,
                Url = SD.ProductAPIBase + "api/Products/" + productId
            });
        }

        public async Task<T> GetAllProductsAsync<T>()
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                AccessToken = null,
                ApiType = SD.ApiType.Get,
                Data = null,
                Url = SD.ProductAPIBase + "api/Products"
            });
        }

        public async Task<T> GetProductByIdAsync<T>(int productId)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                AccessToken = null,
                ApiType = SD.ApiType.Get,
                Data = null,
                Url = SD.ProductAPIBase + "api/Products/" + productId
            });
        }

        public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                AccessToken = null,
                ApiType = SD.ApiType.Put,
                Data = productDto,
                Url = SD.ProductAPIBase + "api/Products"
            });
        }

        #endregion
    }
}
