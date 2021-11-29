
using AutoMapper;
using Integrator.Features.Widgets.DTO;
using Integrator.Features.Widgets.Models;
using Integrator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Integrator.Features.Widgets
{
    [ApiController]
    [Route("[controller]")]
    public class WidgetController : ControllerBase
    {
        private readonly ILogger<WidgetController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WidgetController(ILogger<WidgetController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("Widget")]
        public string CreateWidget([FromBody] WidgetDTO widgetDto)
        {
            var widget = _mapper.Map<Widget>(widgetDto);

            _unitOfWork.Widget.Insert(widget);

            return widget.Id;
        }

        [HttpGet]
        public IEnumerable<WidgetDTO> ListWidgets()
        {
            return _unitOfWork.Widget.ListAll()
                .Select(widget => new WidgetDTO
                {
                    Id = widget.Id,
                    Title = widget.Title,
                });
        }

        [HttpDelete("widget")]
        public string DeleteWidget([FromBody] WidgetDTO widgetDto)
        {
            var widget = _mapper.Map<Widget>(widgetDto);

            _unitOfWork.Widget.Delete(widget);

            return widgetDto.Id;
        }

    }
}