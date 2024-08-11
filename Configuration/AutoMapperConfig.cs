using AutoMapper;
using CoffeeShopAPI.Models;
using CoffeeShopAPI.Models.DTO;

namespace CoffeeShopAPI.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() { 
        
            // Mappers
        
            CreateMap<CoffeeShopDTO, CoffeeShop>().ReverseMap();
        }
    }
}
