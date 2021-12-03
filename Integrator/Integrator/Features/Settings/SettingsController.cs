using System.Collections.Generic;
using Integrator.Features.Settings.DTO;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SettingDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<SettingDTO>> Get()
        {
            _logger.Log(LogLevel.Information, "Get all settings");
            return Ok(_settingsService.GetSettings());
        }

        [HttpGet("test/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SettingDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SettingDTO> GetById(string id)
        {
            _logger.Log(LogLevel.Information, "Get setting by id");
            return Ok(_settingsService.GetById(id));
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> Insert([FromBody] SettingDTO setting)
        {
            _logger.Log(LogLevel.Information, "Create new setting");
            _settingsService.CreateSetting(setting);
            return Ok(true);
        }
    }
}