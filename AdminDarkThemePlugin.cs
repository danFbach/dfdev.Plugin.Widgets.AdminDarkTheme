using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Core.Domain.Cms;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace dfdev.Plugin.Widgets.AdminDarkTheme
{
    /// <summary>
    /// Rename this file and change to the correct type
    /// </summary>
    public class AdminDarkThemePlugin : BasePlugin, IMiscPlugin, IWidgetPlugin
    {
        #region Fields

        private readonly ISettingService _settingService;

        #endregion

        #region Ctor

        public AdminDarkThemePlugin(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public bool HideInWidgetList => false;

        #endregion

        #region Methods
        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return string.Empty;
        }

        public Type GetWidgetViewComponent(string widgetZone)
        {
            if (widgetZone == AdminWidgetZones.HeaderNavbarAfter)
                return typeof(Components.AdminDarkThemeComponent);

            throw new NotImplementedException();
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { AdminWidgetZones.HeaderNavbarAfter });
        }

        /// <summary>
        /// Install the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            await _settingService.SaveSettingAsync(new AdminDarkThemeSettings());

            var widgetSettings = await _settingService.LoadSettingAsync<WidgetSettings>();

            if (!widgetSettings.ActiveWidgetSystemNames.Contains("Widgets.AdminDarkTheme"))
            {
                widgetSettings.ActiveWidgetSystemNames.Add("Widgets.AdminDarkTheme");
                await _settingService.SaveSettingAsync(widgetSettings);
            }

            await base.InstallAsync();
        }

        public override Task UpdateAsync(string currentVersion, string targetVersion)
        {
            return base.UpdateAsync(currentVersion, targetVersion);
        }

        /// <summary>
        /// Uninstall the plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            await base.UninstallAsync();
        }
        #endregion
    }
}
