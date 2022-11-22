using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Jellyfin.Plugin.Jav.Extensions;
using Jellyfin.Plugin.Jav.Service;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.Providers;

namespace Jellyfin.Plugin.Jav.Provider
{
    public class ActorImageProvider : IRemoteImageProvider, IHasOrder
    {
        private readonly JavService _javService;

        public ActorImageProvider(JavService javService)
        {
            _javService = javService;
        }

        public string Name => Constants.PluginName;

        public int Order => 1;

        public bool Supports(BaseItem item) => item is Person;

        public IEnumerable<ImageType> GetSupportedImages(BaseItem item) => new List<ImageType> { ImageType.Primary };

        public Task<IEnumerable<RemoteImageInfo>> GetImages(BaseItem item, CancellationToken cancellationToken)
        {
            var actor = item.GetActor();
            if (actor == null || actor.AvatarUrl == null)
            {
                return Task.FromResult(Enumerable.Empty<RemoteImageInfo>());
            }

            var imageList = new List<RemoteImageInfo> { new() { Type = ImageType.Backdrop, ProviderName = Name, Url = actor.AvatarUrl.ToString() } };
            return Task.FromResult(imageList.AsEnumerable());
        }

        public Task<HttpResponseMessage> GetImageResponse(string url, CancellationToken cancellationToken) => _javService.GetImage(new Uri(url));
    }
}
