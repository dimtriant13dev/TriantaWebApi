using AutoMapper;
using TriantaWeb.API.Models.Domain;
using TriantaWeb.API.Models.DTO;

namespace TriantaWeb.API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles() 
        { 
            CreateMap<Region,RegionDto>().ReverseMap();
            //.ForMember(x=>x.Name,opt=> opt.MapFrom(x=>x.Name))
            CreateMap<AddRegionRequestDto,Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto,Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();


        }
    }

    
}
