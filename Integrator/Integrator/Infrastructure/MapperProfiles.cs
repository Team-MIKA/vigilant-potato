using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Integrator.Features.Settings.DTO;
using Integrator.Features.Settings.Models;
using Integrator.Features.Widgets.DTO;
using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.DTO;
using Integrator.Features.Workspaces.Models;


namespace Integrator.Features.Settings.Mappings
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Setting, SettingDTO>().ReverseMap();
            CreateMap<Workspace, WorkspaceDTO>().ForMember(dst => dst.Widgets, opt => opt.MapFrom(src => src.Widgets)).ReverseMap();
            CreateMap<WorkspaceWidget, WidgetDTO>().IncludeMembers(src => src.Widget).ReverseMap();
            CreateMap<Widget, WidgetDTO>().ReverseMap();
            
        }
    }
}
