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
        
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = _unitOfWork.Categories.ListAll();
            var categoryDTOs = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return Ok(categoryDTOs);
        }

        [HttpPost("[action]")]
        public void InsertCategory([FromBody] CategoryDTO newCategory)
        {
            var category = _mapper.Map<RegistrationCategory>(newCategory);
            category.Id = Guid.NewGuid().ToString();
            category.Created = new DateTime();
            category.Modified = new DateTime();
            _unitOfWork.Categories.Insert(category);
            _unitOfWork.Complete();
        }
        
        [HttpGet("[action]/{orderId}")]
        public ActionResult<IEnumerable<RegistrationDTO>> GetRegistrations(string orderId)
        {
            var registrationsForOrderId = _unitOfWork.Registrations.ListAllByOrderId(orderId);
            var registrationDTOs = _mapper.Map<IEnumerable<RegistrationDTO>>(registrationsForOrderId);
            return Ok(registrationDTOs);
        }
        
        [HttpPost("[action]")]
        public void InsertRegistration([FromBody] CreateRegistrationDTO newRegistration)
        {
            var registration = new Registration
            {
                OrderId = newRegistration.OrderId,
                EndTime = newRegistration.EndTime,
                StartTime = newRegistration.StartTime,
                RegistrationCategoryId = newRegistration.CategoryId
            };
            _unitOfWork.Registrations.Insert(registration);
            _unitOfWork.Complete();
        }
    }
}