using System.Collections.Generic;
using Integrator.Features.Settings.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Integrator.Features.Settings
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<SettingsController> logger;
        private readonly ISettingsService settingsService;

        public HealthController(ILogger<SettingsController> logger, ISettingsService settingsService)
        {
            this.logger = logger;
            this.settingsService = settingsService;
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<SettingDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<SettingDto>> Get()
        {
            logger.Log(LogLevel.Information, "Health OK");
            return Ok("Health: OK!");
        }
    }
}