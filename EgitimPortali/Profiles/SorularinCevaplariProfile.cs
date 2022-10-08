using AutoMapper;
using EgitimPortali.DTO;
using EgitimPortali.Models;

namespace EgitimPortali.Profiles
{
    public class SorularinCevaplariProfile : Profile
    {
        public SorularinCevaplariProfile()
        {
            CreateMap<SorularinCevaplari, SoruCevapDto>();
            CreateMap<SoruCevapDto, SorularinCevaplari>();
        }
    }
}
