using AutoMapper;
using Integrator.Features.Settings.DTO;
using Integrator.Features.Settings.Models;
using Integrator.Features.TimeSmart.DTO;
using Integrator.Features.TimeSmart.Models;

namespace Integrator.Infrastructure
{
    public class MapperProfiles :  Profile
    {
        public MapperProfiles()
        {
            CreateMap<Setting, SettingDTO>();
            CreateMap<RegistrationCategory, CategoryDTO>().ReverseMap();
            CreateMap<Setting, SettingDTO>().ReverseMap();      
            CreateMap<Workspace, WorkspaceDTO>()
                .ForMember(dst => dst.Widgets, opt => opt
                    .MapFrom(src => src.Widgets))
                .ReverseMap();
                       
            CreateMap<WorkspaceWidget, WidgetDTO>()
                .IncludeMembers(src => src.Widget)
                .ReverseMap()
                .ForMember(dst => dst.Id, act => act.Ignore());
            
            CreateMap<WorkspaceWidget, WorkspaceDTO>()
                .IncludeMembers(src => src.Workspace)
                .ReverseMap()
                .ForMember(dst => dst.Id, act => act.Ignore());           
            
            // CreateMap<WidgetDTO, WorkspaceWidget>().ForSourceMember()
            //.ForMember(dest => dest.WidgetId, opt => opt.MapFrom(src => src.Id)).ForMember(dest => dest.WorkspaceId, opt => opt.MapFrom(src => src.Id));
            CreateMap<Widget, WidgetDTO>().ReverseMap();
        }
    }
}
