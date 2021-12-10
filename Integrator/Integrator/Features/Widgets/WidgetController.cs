
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
using Integrator.Features.Settings.DTO;
using Microsoft.AspNetCore.Http;

namespace Integrator.Features.Widgets
{
    [ApiController]
    [Route("[controller]")]
    public class WidgetController : ControllerBase
    {
        private readonly IWidgetService widgetService;


        public WidgetController(IWidgetService widgetService)
        {
            this.widgetService = widgetService;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateWidget([FromBody] WidgetDto widgetDto)
        {
            if (!ModelState.IsValid) throw new Exception("Error creating a widget");

            var widgetId = widgetService.CreateWidget(widgetDto);

            return Ok(widgetId);

        }

        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WidgetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListWidgets()
        {
            if (!ModelState.IsValid) throw new Exception("Error retrieving a list of widgets");
            var res = widgetService.ListWidgets();

            return Ok(res);
        }

        [HttpDelete("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteWidget(string id)
        {
            if (!ModelState.IsValid) throw new Exception("Error deleting widget: " + id);
            
            var widgetId = widgetService.DeleteWidget(id);

            return Ok(widgetId);

        }

    }
}