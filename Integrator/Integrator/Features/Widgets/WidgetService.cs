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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public WidgetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public string CreateWidget(WidgetDto widgetDto)
        {
            var widget = mapper.Map<Widget>(widgetDto);

            unitOfWork.Widgets.Insert(widget);
            unitOfWork.Complete();

            return widget.Id;
        }

        public string DeleteWidget(string id)
        {
            unitOfWork.Widgets.Delete(id);
            unitOfWork.Complete();

            return id;
        }

        public IEnumerable<WidgetDto> ListWidgets()
        {
            var res = unitOfWork.Widgets.GetAll()
            .Select(widget => new WidgetDto
            {
                Id = widget.Id,
                Title = widget.Title,
            });

            return res;
        }
    }
}
