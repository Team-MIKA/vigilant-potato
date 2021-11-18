using System;
using System.Collections.Generic;
using System.Linq;
using Integrator.Features.Settings.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Integrator.Features.Settings
{
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILogger<SettingsController> logger)
        {
            _logger = logger;
        }
        
        // [HttpGet]
        // public IEnumerable<Setting> Get()
        // {
        //     return ""
        // }
    }
}