using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Components;

namespace dfdev.Plugin.Widgets.AdminDarkTheme.Components
{
    public class AdminDarkThemeComponent : NopViewComponent
    {
        public AdminDarkThemeComponent() { }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("~/Plugins/Widgets.AdminDarkTheme/Views/Components/AdminDarkTheme.cshtml"));
        }
    }
}
