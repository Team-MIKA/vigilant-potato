using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Integrator.Features.Settings.DTO;
using Integrator.Features.Settings.Models;

namespace Integrator.Features.Settings.Mappings
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Setting, SettingDTO>();
        }
    }
}
