using System.Collections.Generic;
using AutoMapper;
using Integrator.Features.Settings.DTO;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SettingsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void CreateSetting(SettingDto setting)
        {
            unitOfWork.Settings.Insert(mapper.Map<Setting>(setting));
            unitOfWork.Complete();
        }

        public IEnumerable<SettingDto> GetSettings()
        {
            return mapper.Map<IEnumerable<SettingDto>>(unitOfWork.Settings.GetAll());
        }

        public SettingDto GetById(string id)
        {
            return mapper.Map<SettingDto>(unitOfWork.Settings.GetById(id));
        }
    }
}