using ApiTest.Dtos;
using ApiTest.Models;
using AutoMapper;

namespace ApiTest.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
