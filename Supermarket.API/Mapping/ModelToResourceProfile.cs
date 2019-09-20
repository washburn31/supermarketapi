﻿using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Extensions;
using Supermarket.API.Resources;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            this.CreateMap<Category, CategoryResource>();
            this.CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}
