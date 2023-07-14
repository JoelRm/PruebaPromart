using AutoMapper;
using PruebaPromart.DTO.Request;
using PruebaPromart.Entities;
using PruebaPromart.Entities.Complex;

namespace PruebaPromart.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ClientInfo, Client>();
            CreateMap<Client, ClientInfo > ();
            CreateMap<DtoClient, Client>();
        }
    }
}
