using Mango.Services.ProductAPI.Dtos;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/Products")]
    public class ProductAPIController : ControllerBase
    {
        #region Fields

        private readonly IProductRepository _productRepository;
        protected ResponseDto _response;

        #endregion

        #region Constructor

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<object> GetProducts()
        {
            try
            {
                IEnumerable<ProductDto> products = await _productRepository.GetProducts();
                _response.Result = products;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>
                {
                    ex.Message
                };
            }

            return _response;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<object> GetProduct(int productId)
        {
            try
            {
                ProductDto product = await _productRepository.GetProductById(productId);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>
                {
                    ex.Message
                };
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> CreateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto product = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>
                {
                    ex.Message
                };
            }

            return _response;
        }

        [HttpPut]
        public async Task<object> UpdateProduct([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto product = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>
                {
                    ex.Message
                };
            }

            return _response;
        }

        [HttpDelete]
        public async Task<object> DeleteProduct(int productId)
        {
            try
            {
                bool result = await _productRepository.DeleteProduct(productId);
                _response.Result = result;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>
                {
                    ex.Message
                };
            }

            return _response;
        }

        #endregion
    }
}
