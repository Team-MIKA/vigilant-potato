using System;
using System.Collections.Generic;
using AutoMapper;
using Integrator.Features.Settings;
using Integrator.Features.TimeSmart.DTO;
using Integrator.Features.TimeSmart.Models;
using Integrator.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Integrator.Features.TimeSmart
{
    [ApiController]
    [Route("[controller]")]
    public class TimeSmartController : ControllerBase
    {
        private readonly ILogger<SettingsController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TimeSmartController(ILogger<SettingsController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IEnumerable<CategoryDto> Get()
        {
            var categories = _unitOfWork.Categories.ListAll();
            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoryDtos;
        }

        [HttpPost]
        public void Insert([FromBody] CategoryDto newCategory)
        {
            var category = _mapper.Map<RegistrationCategory>(newCategory);
            category.Id = Guid.NewGuid().ToString();
            _unitOfWork.Categories.Insert(category);
            _unitOfWork.Complete();
        }
    }
}