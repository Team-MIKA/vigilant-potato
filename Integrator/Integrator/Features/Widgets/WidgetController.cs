
using System;
using AutoMapper;
using Integrator.Features.Widgets.DTO;
using Integrator.Features.Widgets.Models;
using Integrator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost("[action]")]
        public string CreateWidget([FromBody] WidgetDTO widgetDto)
        {
            var widget = _mapper.Map<Widget>(widgetDto);

            _unitOfWork.Widgets.Insert(widget);

            _unitOfWork.Complete();

            return widget.Id;


        }

        [HttpGet("[action]")]
        public IEnumerable<WidgetDTO> ListWidgets()
        {
            return _unitOfWork.Widgets.ListAll()
                .Select(widget => new WidgetDTO
                {
                    Id = widget.Id,
                    Title = widget.Title,
                });
        }

        [HttpDelete("[action]/{id}")]
        public string DeleteWidget(string id)
        {
           
            var widget = new Widget { Id = id };
            _unitOfWork.Widgets.Delete(widget);
            _unitOfWork.Complete();
            
            
            return id;

        }

    }
}