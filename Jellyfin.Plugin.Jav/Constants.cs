using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.RegexOptions;

namespace Jellyfin.Plugin.Jav
{
    public static class Constants
    {
        public const string PluginName = "Jav";
        public static readonly Regex ChineseSubtitleSuffix = new Regex(@"[-_](C|C2|CH)($|[-_])", IgnoreCase);
    }
}
