using AutoMapper;
using Integrator.Features.Widgets.DTO;
using Integrator.Infrastructure;
using System;
using Integrator.Features.Widgets.Models;
using Integrator.Features.Workspaces.DTO;
using Integrator.Features.Workspaces.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integrator.Features.Widgets
{
    public class WidgetService : IWidgetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WidgetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public string CreateWidget(WidgetDTO widgetDto)
        {
            var widget = _mapper.Map<Widget>(widgetDto);

            _unitOfWork.Widgets.Insert(widget);
            _unitOfWork.Complete();

            return widget.Id;
        }

        public WidgetDTO DeleteWidget(WidgetDTO widgetDto)
        {
            //tidligere brugte vi det her, dur det nye med mapper? 
            //var widget = new Widget { Id = widgetDto.Id };

            var widget = _mapper.Map<Widget>(widgetDto);

            _unitOfWork.Widgets.Delete(widget);
            _unitOfWork.Complete();

            return widgetDto;
        }

        public IEnumerable<WidgetDTO> ListWidgets()
        {
            var res = _unitOfWork.Widgets.ListAll()
            .Select(widget => new WidgetDTO
            {
                Id = widget.Id,
                Title = widget.Title,
            });

            return res;
        }
    }
}
