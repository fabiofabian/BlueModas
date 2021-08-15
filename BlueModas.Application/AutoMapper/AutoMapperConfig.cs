using AutoMapper;
using BlueModas.Application.ViewModels;
using BlueModas.Domain.Models;

namespace BlueModas.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings() 
        {
            return new MapperConfiguration(cfg => {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
                cfg.CreateMap<Product, ProductViewModel>();
            });
        }
    }
}
