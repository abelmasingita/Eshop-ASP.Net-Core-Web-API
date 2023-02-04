﻿using AutoMapper;
using eshopWebAPI.Dto;
using eshopWebAPI.Models;

namespace eshopWebAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<UserDto, User>();
        }
    }
}
