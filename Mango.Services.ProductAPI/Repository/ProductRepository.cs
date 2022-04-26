using AutoMapper;
using Mango.Services.ProductAPI.Dtos;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.ProductDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region Fields

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            if (product.ProductId > 0)
            {
                _context.Products.Update(product);
            }
            else
            {
                _context.Products.Add(product);
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product != null)
            {
                _context.Products.Remove(product);
            }

            return Convert.ToBoolean(await _context.SaveChangesAsync());
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var lstProducts = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(lstProducts);
        }

        #endregion
    }
}
