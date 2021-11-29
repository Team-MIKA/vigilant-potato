using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Integrator.Features.Settings.DTO;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Integrator.Features.Settings
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly ISettingsService _settingsService;

        public SettingsController(ILogger<SettingsController> logger, ISettingsService settingsService)
        {
            _logger = logger;
            _settingsService = settingsService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<SettingDTO>> Get()
        {
            return Ok(_settingsService.GetSettings());
        }

        [HttpGet("test/{id}")]
        public ActionResult<SettingDTO> GetById(string id)
        {
            return Ok(_settingsService.GetById(id));
        }
    }
}