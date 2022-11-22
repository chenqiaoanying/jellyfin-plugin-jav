using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Jellyfin.Plugin.Jav.Extensions;
using Jellyfin.Plugin.Jav.Model;
using Jellyfin.Plugin.Jav.Service;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Providers;
using MediaBrowser.Model.Providers;

namespace Jellyfin.Plugin.Jav.Provider
{
    public class ActorProvider : IRemoteMetadataProvider<Person, PersonLookupInfo>, IHasOrder
    {
        private readonly JavService _javService;

        public ActorProvider(JavService javService)
        {
            _javService = javService;
        }

        public int Order => 1;

        public string Name => Constants.PluginName;

        public async Task<IEnumerable<RemoteSearchResult>> GetSearchResults(PersonLookupInfo searchInfo, CancellationToken cancellationToken)
        {
            var indexes = await _javService.SearchActor(searchInfo.Name).ConfigureAwait(false) ?? new List<ActorIndex>(0);
            return from index in indexes
                select new RemoteSearchResult
                {
                    Name = index.Name, SearchProviderName = Name, ImageUrl = index.AvatarUrl?.ToString(),
                };
        }

        public async Task<MetadataResult<Person>> GetMetadata(PersonLookupInfo info, CancellationToken cancellationToken)
        {
            var actor = info.GetActor();
            if (actor == null)
            {
                actor = await _javService.AutoSearchActor(info.Name).ConfigureAwait(false);
                if (actor == null)
                {
                    return new MetadataResult<Person> { HasMetadata = false };
                }

                info.SetActor(actor);
            }

            return new MetadataResult<Person>
            {
                Item = new Person
                {
                    Name = actor.Name,
                    PremiereDate = actor.Birthday,
                    ProductionYear = actor.Birthday.Year,
                    Overview = FormatOverview(actor)
                },
                HasMetadata = true
            };
        }

        public Task<HttpResponseMessage> GetImageResponse(string url, CancellationToken cancellationToken) => _javService.GetImage(new Uri(url));

        private static string FormatOverview(Actor actor)
        {
            var info = new List<(string Key, string? Value)>
            {
                ("別名", string.Join(", ", actor.Aliases)),
                ("三围", actor.Measurements),
                ("罩杯", actor.CupSize?.ToString()),
                ("出道日期", actor.DebutDate?.ToString("yyyy年MM月dd日", CultureInfo.InvariantCulture)),
                ("身高", actor.Height > 0 ? $"{actor.Height}cm" : string.Empty),
                ("血型", actor.BloodType),
                ("国籍", actor.Nationality)
            };

            return string.Join(
                "\n<br>\n",
                from pair in info
                where !string.IsNullOrWhiteSpace(pair.Value)
                select $"{pair.Key}: {pair.Value}");
        }
    }
}
