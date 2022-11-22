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
using Movie = MediaBrowser.Controller.Entities.Movies.Movie;

namespace Jellyfin.Plugin.Jav.Provider
{
    public class MovieImageProvider : IRemoteImageProvider, IHasOrder
    {
        private readonly JavService _javService;

        public MovieImageProvider(JavService javService)
        {
            _javService = javService;
        }

        public string Name => Constants.PluginName;

        public int Order => 1;

        public bool Supports(BaseItem item) => item is Movie;

        public IEnumerable<ImageType> GetSupportedImages(BaseItem item) => new List<ImageType> { ImageType.Backdrop, ImageType.Thumb, ImageType.Primary };

        public Task<IEnumerable<RemoteImageInfo>> GetImages(BaseItem item, CancellationToken cancellationToken)
        {
            var movie = item.GetMovie();
            if (movie == null)
            {
                return Task.FromResult(Enumerable.Empty<RemoteImageInfo>());
            }

            var imageList = new List<RemoteImageInfo>(2 + movie.Samples.Count);
            if (movie.CoverUrl != null)
            {
                imageList.Add(new() { Type = ImageType.Primary, ProviderName = Name, Url = $"{movie.CoverUrl}#Primary" });
                imageList.Add(new() { Type = ImageType.Backdrop, ProviderName = Name, Url = movie.CoverUrl.ToString() });
            }

            imageList.AddRange(
                from sampleUrl in movie.Samples
                select new RemoteImageInfo { Type = ImageType.Thumb, ProviderName = Name, Url = sampleUrl.ToString() });
            return Task.FromResult(imageList.AsEnumerable());
        }

        public Task<HttpResponseMessage> GetImageResponse(string url, CancellationToken cancellationToken) => _javService.GetImage(new Uri(url));
    }
}
