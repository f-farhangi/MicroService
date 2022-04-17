using AutoMapper;
using Mango.Services.ProductAPI.Dtos;
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

        public Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProduct(int productId)
        {
            throw new NotImplementedException();
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
