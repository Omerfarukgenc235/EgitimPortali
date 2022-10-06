using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;

namespace EgitimPortali.Profiles
{
    public class KonuProfile : Profile
    {
        public KonuProfile()
        {
            CreateMap<Konular, KonularDto>();
            CreateMap<KonularDto, Konular>();
        }
    }
}
