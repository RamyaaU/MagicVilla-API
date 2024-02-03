using AutoMapper;
using MagicVilla_API.Models;
using MagicVilla_API.Models.DTO;

namespace MagicVilla_API
{
    public class MappingConfig  : Profile
    {
        public MappingConfig() 
        {
            //one way to map
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();

            //another way to map
            //instead of writing 2 lines, reverse mapping can be used
            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();
        }
    }
}
