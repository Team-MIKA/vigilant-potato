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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SettingsController(ILogger<SettingsController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        [HttpGet("test/{id}")]
        public ActionResult GetById(string id)
        {
            throw new Exception("Something bad happened!");
        }
    }
}