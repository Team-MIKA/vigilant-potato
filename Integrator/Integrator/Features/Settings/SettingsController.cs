using System;
using System.Collections.Generic;
using System.Linq;
using Integrator.Features.Settings.DTO;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Integrator.Features.Settings
{
    public class SettingsController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SettingsController(ILogger<SettingsController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        public IEnumerable<SettingDTO> Get()
        {
            return _unitOfWork.Settings.ListAll()
                .Select(setting => new SettingDTO
                {
                    Id = setting.Id, 
                    Name = setting.Name
                });
        }
    }
}