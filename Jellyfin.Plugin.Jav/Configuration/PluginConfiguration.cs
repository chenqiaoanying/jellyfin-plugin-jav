using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.Jav.Configuration;

public class PluginConfiguration : BasePluginConfiguration
{
    public string Version { get; } = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;

    public Backend Backend { get; set; } = new();

    public General General { get; set; } = new();

    public Template Template { get; set; } = new();

    public Replacement Replacement { get; set; } = new();
}

public class Backend
{
    public string Server { get; set; } = "https://api.javtube.internal";

    public string Token { get; set; } = string.Empty;
}

public class General
{
    public int ImageQuality { get; set; } = 100;

    public bool EnableCollectionsBySeries { get; set; }

    public bool EnableChineseSubtitleGenre { get; set; }
}

public class Template
{
    public string TitleTemplate { get; set; } = "{number} {title}";

    public string TaglineTemplate { get; set; } = "配信開始日 {date}";

    public string PlaceholderIfNull { get; set; } = "NULL";
}

public class Replacement
{
    public bool EnableGenreReplacement { get; set; }

    public string RawGenreReplacementTable
    {
        get => EncodeTable(GenreReplacementTable);
        set => GenreReplacementTable = DecodeTable(value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public Dictionary<string, string> GenreReplacementTable { get; private set; } = new(0);

    public bool EnableActorReplacement { get; set; }

    public string RawActorReplacementTable
    {
        get => EncodeTable(ActorReplacementTable);
        set => ActorReplacementTable = DecodeTable(value);
    }

    [JsonIgnore]
    [XmlIgnore]
    public Dictionary<string, string> ActorReplacementTable { get; private set; } = new(0);

    private static Dictionary<string, string> DecodeTable(string rawTable) =>
        rawTable.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None)
            .Select(line => line.Split(":"))
            .Where(line => line.Length == 2)
            .ToDictionary(values => values[0], values => values[1]);

    private static string EncodeTable(Dictionary<string, string> table) =>
        string.Join("\n", table.Select(pair => $"{pair.Key}:{pair.Value}"));
}
