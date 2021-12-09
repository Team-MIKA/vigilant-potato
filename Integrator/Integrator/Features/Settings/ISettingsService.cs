using System.Collections.Generic;
using Integrator.Features.Settings.DTO;

namespace Integrator.Features.Settings
{
    public interface ISettingsService
    {
        void CreateSetting(SettingDto setting);
        IEnumerable<SettingDto> GetSettings();
        SettingDto GetById(string id);
    }
}