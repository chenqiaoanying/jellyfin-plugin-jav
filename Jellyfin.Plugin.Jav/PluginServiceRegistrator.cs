using Jellyfin.Plugin.Jav.Service;
using MediaBrowser.Common.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace Jellyfin.Plugin.Jav
{
    public class PluginServiceRegistrator : IPluginServiceRegistrator
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<JavService>();
        }
    }
}
