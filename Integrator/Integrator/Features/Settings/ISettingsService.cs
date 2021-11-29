using Integrator.Features.Settings.DTO;

namespace Integrator.Features.Settings
{
    public interface ISettingsService
    {
        void CreateSetting(SettingDTO setting);
    }
}