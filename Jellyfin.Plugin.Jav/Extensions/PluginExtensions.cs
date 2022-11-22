using System.Text.Json;
using Jellyfin.Plugin.Jav.Model;
using MediaBrowser.Model.Entities;

namespace Jellyfin.Plugin.Jav.Extensions
{
    public static class PluginExtensions
    {
        public static IHasProviderIds SetMovie(this IHasProviderIds result, Movie movie)
        {
            result.ProviderIds[$"{Constants.PluginName}-Movie"] = movie.ToJson();
            return result;
        }

        public static Movie? GetMovie(this IHasProviderIds result)
        {
            try
            {
                return result.ProviderIds.TryGetValue($"{Constants.PluginName}-Movie", out var json) ? JsonSerializer.Deserialize<Movie>(json) : null;
            }
            catch (JsonException)
            {
                result.ProviderIds.Remove($"{Constants.PluginName}-Movie");
                return null;
            }
        }

        public static IHasProviderIds SetActor(this IHasProviderIds result, Actor actor)
        {
            result.ProviderIds[$"{Constants.PluginName}-Actor"] = actor.ToJson();
            return result;
        }

        public static Actor? GetActor(this IHasProviderIds result)
        {
            try
            {
                return result.ProviderIds.TryGetValue($"{Constants.PluginName}-Actor", out var json) ? JsonSerializer.Deserialize<Actor>(json) : null;
            }
            catch (JsonException)
            {
                result.ProviderIds.Remove($"{Constants.PluginName}-Actor");
                return null;
            }
        }
    }
}
