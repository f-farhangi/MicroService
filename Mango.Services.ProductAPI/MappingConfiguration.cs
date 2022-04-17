using AutoMapper;
using Mango.Services.ProductAPI.Dtos;
using Mango.Services.ProductAPI.Models;

namespace Mango.Services.ProductAPI
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterConfig()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });

            return mapperConfig;
        }
    }
}
