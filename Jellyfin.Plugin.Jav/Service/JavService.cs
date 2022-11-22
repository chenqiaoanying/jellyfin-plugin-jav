using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Jellyfin.Plugin.Jav.Configuration;
using Jellyfin.Plugin.Jav.Extensions;
using Jellyfin.Plugin.Jav.Model;
using Microsoft.Extensions.Logging;
using static System.StringComparison;

namespace Jellyfin.Plugin.Jav.Service
{
    public class JavService
    {
        private readonly ILogger<JavService> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly Backend _backend = Plugin.Instance.Configuration.Backend;

        public JavService(ILogger<JavService> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public Task<Movie?> AutoSearchMovie(string keyword) =>
            HttpGet<Movie>(Uri(_backend.Server, "/movie/auto/search", new Dictionary<string, object?> { { "keyword", keyword } }));

        public Task<List<MovieIndex>?> SearchMovie(string keyword) =>
            HttpGet<List<MovieIndex>>(Uri(_backend.Server, "/movie/search", new Dictionary<string, object?> { { "keyword", keyword } }));

        public Task<Movie?> GetMovieByIndexAndMerge(IEnumerable<MovieIndex> indexes) =>
            HttpPost<Movie>(Uri(_backend.Server, "/movie/get"), indexes);

        public Task<Actor?> AutoSearchActor(string name, string? number = null) =>
            HttpGet<Actor>(Uri(_backend.Server, "/actor/auto/search", new Dictionary<string, object?> { { "name", name }, { "number", number } }));

        public Task<List<ActorIndex>?> SearchActor(string name) =>
            HttpGet<List<ActorIndex>>(Uri(_backend.Server, "/actor/search", new Dictionary<string, object?> { { "name", name } }));

        public Task<Actor?> GetActor(ActorIndex index) =>
            HttpPost<Actor>(Uri(_backend.Server, "/actor/get"), index);

        public Task<Dictionary<string, string>?> SearchAvatarByName(IEnumerable<string> names) =>
            HttpGet<Dictionary<string, string>>(Uri(_backend.Server, "/actor/avatar/search", new Dictionary<string, object?> { { "names", string.Join(",", names) } }));

        public async Task<HttpResponseMessage> GetImage(Uri uri)
        {
            _logger.LogInformation("call GetImage, uri={Uri}", uri);
            var pictureUri = new UriBuilder(uri) { Fragment = null }.Uri;
            var enableAutoCut = uri.Fragment.Equals("#Primary", OrdinalIgnoreCase);
            using var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = Uri(_backend.Server, "/image/proxy", new Dictionary<string, object?> { { "url", pictureUri }, { "enableAutoCut", enableAutoCut } }), Headers = { Accept = { new MediaTypeWithQualityHeaderValue("image/jpeg", Plugin.Instance.Configuration.General.ImageQuality / 100.0) } } };
            return await _clientFactory.CreateClient().SendAsync(request).ConfigureAwait(false);
        }

        private async Task<T?> HttpGet<T>(Uri uri)
        {
            _logger.LogInformation("call HttpGet, uri={Uri}", uri);
            using var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = uri, Headers = { AcceptEncoding = { new StringWithQualityHeaderValue("gzip") } } };
            using var response = await _clientFactory.CreateClient().SendAsync(request).ConfigureAwait(false);
            var responseMessage = await response.Content.ReadFromJsonAsync<ResponseMessage<T>>().ConfigureAwait(false);
            if (responseMessage?.Error != null)
            {
                _logger.LogError("error from api, code={Code}, message={Message}", responseMessage.Error.Code, responseMessage.Error.Message);
            }

            return responseMessage == null ? default : responseMessage.Data;
        }

        private async Task<T?> HttpPost<T>(Uri uri, object content)
        {
            _logger.LogInformation("call HttpPost, uri={Uri}", uri);
            using var request = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = uri, Headers = { AcceptEncoding = { new StringWithQualityHeaderValue("gzip") } } };
            request.Content = new StringContent(content.ToJson());
            using var response = await _clientFactory.CreateClient().SendAsync(request).ConfigureAwait(false);
            var responseMessage = await response.Content.ReadFromJsonAsync<ResponseMessage<T>>().ConfigureAwait(false);
            if (responseMessage?.Error != null)
            {
                _logger.LogError("error from api, code={Code}, message={Message}", responseMessage.Error.Code, responseMessage.Error.Message);
            }

            return responseMessage == null ? default : responseMessage.Data;
        }

        private static Uri Uri(string baseUrl, string path, Dictionary<string, object?>? query = null) =>
            new UriBuilder(baseUrl) { Path = path, Query = query == null ? null : string.Join("&", query.Where(pair => pair.Value != null).Select(pair => $"{pair.Key}={pair.Value}")) }.Uri;
    }
}
