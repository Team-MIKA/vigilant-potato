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
        private readonly ILogger<SettingsController> logger;
        private readonly ISettingsService settingsService;

        public SettingsController(ILogger<SettingsController> logger, ISettingsService settingsService)
        {
            this.logger = logger;
            this.settingsService = settingsService;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SettingDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<SettingDto>> Get()
        {
            logger.Log(LogLevel.Information, "Get all settings");
            return Ok(settingsService.GetSettings());
        }

        [HttpGet("test/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SettingDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<SettingDto> GetById(string id)
        {
            logger.Log(LogLevel.Information, "Get setting by id");
            return Ok(settingsService.GetById(id));
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> Insert([FromBody] SettingDto setting)
        {
            logger.Log(LogLevel.Information, "Create new setting");
            settingsService.CreateSetting(setting);
            return Ok(true);
        }
    }
}