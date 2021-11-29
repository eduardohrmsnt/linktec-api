using AutoMapper;
using LinkTec.Api.Entities;
using LinkTec.Api.Models;

namespace LinkTec.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ContatoCliente, ContatoClienteModel>().ReverseMap();
        }
    }
}
