using System.Collections.Generic;
using Integrator.Features.Settings.DTO;
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
            // log er blot test
            _logger.Log(LogLevel.Information, "Get all settings");
            return Ok(_settingsService.GetSettings());
        }

        [HttpGet("test/{id}")]
        public ActionResult<SettingDTO> GetById(string id)
        {
            // log er blot test
            _logger.Log(LogLevel.Information, "Get setting by id");
            return Ok(_settingsService.GetById(id));
        }
        
        [HttpPost]
        public ActionResult<bool> Insert([FromBody] SettingDTO setting)
        {
            // log er blot test
            _logger.Log(LogLevel.Information, "Create new setting");
            _settingsService.CreateSetting(setting);
            return Ok(true);
        }
    }
}