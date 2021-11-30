﻿
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
        public async Task<IActionResult> CreateWidget([FromBody] WidgetDTO widgetDto)
        {
            if (!ModelState.IsValid) throw new Exception("Error creating widget");
            var widget = _mapper.Map<Widget>(widgetDto);

            _unitOfWork.Widgets.Insert(widget);

            _unitOfWork.Complete();

            return Ok(widget.Id);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListWidgets()
        {
            if (!ModelState.IsValid) throw new Exception("Error retrieving a list of widgets");
            var res = _unitOfWork.Widgets.ListAll()
                .Select(widget => new WidgetDTO
                {
                    Id = widget.Id,
                    Title = widget.Title,
                });

            return Ok(res);

        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteWidget(string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error deleting widget: " + id);
            var widget = new Widget { Id = id };
            _unitOfWork.Widgets.Delete(widget);
            _unitOfWork.Complete();

            return Ok(id);

        }

    }
}