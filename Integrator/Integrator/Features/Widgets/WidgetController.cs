﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Integrator.Features.Workspaces.DTO;
using Integrator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            var widget = _mapper.Map<WidgetDTO>(widgetDto);

            _unitOfWork.Widget.Insert(widget);

            return widget.Id;
        }

    }
}