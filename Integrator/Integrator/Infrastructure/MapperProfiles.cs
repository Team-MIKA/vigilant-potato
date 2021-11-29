using AutoMapper;
using Integrator.Features.Settings.DTO;
using Integrator.Features.Settings.Models;

namespace Integrator.Infrastructure
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Setting, SettingDTO>().ReverseMap();
        }
    }
}
