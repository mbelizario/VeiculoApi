using AutoMapper;
using Core.Models;
using WebApi.ViewModels;

namespace WebApi.Configuration
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Marca, MarcaViewModel>().ReverseMap();
        }
    }
}
