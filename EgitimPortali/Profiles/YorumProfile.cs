using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;

namespace EgitimPortali.Profiles
{
    public class YorumProfile : Profile
    {
        public YorumProfile()
        {
            CreateMap<Yorumlar, YorumlarDto>();
            CreateMap<YorumlarDto, Yorumlar>();
        }
    }
}
