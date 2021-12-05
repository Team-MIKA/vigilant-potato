using AutoMapper;
using Integrator.Features.Settings.DTO;
using Integrator.Features.Settings.Models;
using Integrator.Features.TimeSmart.DTO;
using Integrator.Features.TimeSmart.Models;

namespace Integrator.Infrastructure
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Setting, SettingDTO>();
            CreateMap<RegistrationCategory, CategoryDTO>().ReverseMap();
        }
    }
}
