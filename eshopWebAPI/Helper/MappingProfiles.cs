using AutoMapper;
using eshopWebAPI.Data.Dto.AppUser;
using eshopWebAPI.Data.Dto.Order;
using eshopWebAPI.Dto.Product;
using eshopWebAPI.Dto.User;
using eshopWebAPI.Models;

namespace eshopWebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();

            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, RegisterUserDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>().ReverseMap();

        }
    }
}
