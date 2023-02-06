using AutoMapper;
using eshopWebAPI.Dto;
using eshopWebAPI.Models;

namespace eshopWebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
