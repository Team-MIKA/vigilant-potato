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


namespace Integrator.Infrastructure
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Setting, SettingDTO>().ReverseMap();
            
            CreateMap<Workspace, WorkspaceDTO>().ForMember(dst => dst.Widgets, opt => opt.MapFrom(src => src.Widgets)).ReverseMap();
            
            
            CreateMap<WorkspaceWidget, WidgetDTO>().IncludeMembers(src => src.Widget);
            
            CreateMap<WidgetDTO, WorkspaceWidget>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.Widget, act => act.Ignore())
                .ForMember(dest => dest.WidgetId, opt => opt
                    .MapFrom(src => src.Id));
            
            CreateMap<WorkspaceWidget, WorkspaceDTO>().IncludeMembers(src => src.Workspace);
            
            CreateMap<WorkspaceDTO, WorkspaceWidget>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.Workspace, act => act.Ignore())
                .ForMember(dest => dest.WorkspaceId, opt => opt
                    .MapFrom(src => src.Id));

            
            
            // CreateMap<WidgetDTO, WorkspaceWidget>().ForSourceMember()
            //.ForMember(dest => dest.WidgetId, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.WorkspaceId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Widget, WidgetDTO>().ReverseMap();
            
        }
    }
}
