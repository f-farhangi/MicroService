using Mango.Web.Models.Dtos;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        #region Fields

        private readonly IProductService _productService;

        #endregion

        #region Constructor

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> products = new();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();

            if (response.IsSuccess && response.Result != null)
            {
                products = JsonConvert.DeserializeObject<List<ProductDto>>(response.Result.ToString());
            }

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProductAsync<ResponseDto>(product);

                if (response.IsSuccess && response.Result != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> ProductUpdate(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId);

            if (response.IsSuccess && response.Result != null)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(response.Result.ToString());
                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductUpdate(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProductAsync<ResponseDto>(product);

                if (response.IsSuccess && response.Result != null)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId);

            if (response.IsSuccess && response.Result != null)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(response.Result.ToString());
                return View(product);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteProductsAsync<ResponseDto>(product.ProductId);

                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }

            return View(product);
        }

        #endregion
    }
}
