using System.Collections.Generic;
using AutoMapper;
using Integrator.Features.Settings.DTO;
using Integrator.Features.Settings.Models;
using Integrator.Infrastructure;

namespace Integrator.Features.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SettingsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void CreateSetting(SettingDTO setting)
        {
            _unitOfWork.Settings.Insert(_mapper.Map<Setting>(setting));
            _unitOfWork.Complete();
        }

        public IEnumerable<SettingDTO> GetSettings()
        {
            return _mapper.Map<IEnumerable<SettingDTO>>(_unitOfWork.Settings.GetAll());
        }

        public SettingDTO GetById(string id)
        {
            return _mapper.Map<SettingDTO>(_unitOfWork.Settings.GetById(id));
        }
    }
}