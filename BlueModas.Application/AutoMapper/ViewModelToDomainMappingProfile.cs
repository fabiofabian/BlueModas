using AutoMapper;
using BlueModas.Application.ViewModels;
using BlueModas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueModas.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<ProductVariant, ProductVariantViewModel>();
            CreateMap<ProductVariantImage, ProductVariantImageViewModel>();
        }
    }
}
