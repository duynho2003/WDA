using AutoMapper;
using Lab08.Models;
using Lab08.ViewModels;

namespace Lab08.MappingConfiguration
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() {
            CreateMap<Customer,CustomerViewModel>();

        }
    }
}
