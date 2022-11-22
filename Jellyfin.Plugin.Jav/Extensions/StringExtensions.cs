using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Jellyfin.Plugin.Jav.Extensions
{
    public static class StringExtensions
    {
        public static string ToJson(this object any) => JsonSerializer.Serialize(any, new JsonSerializerOptions { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) });
    }
}
