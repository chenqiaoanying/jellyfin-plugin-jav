using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace Jellyfin.Plugin.Jav.Model
{
    public record Movie(
        [property: JsonPropertyName("provider")] string Provider,
        [property: JsonPropertyName("detailPageUrl")] Uri DetailPageUrl,
        [property: JsonPropertyName("number")] string Number,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("coverUrl")] Uri? CoverUrl,
        [property: JsonPropertyName("releaseDate")] DateTime? ReleaseDate,
        [property: JsonPropertyName("description")] string? Description,
        [property: JsonPropertyName("director")] string? Director,
        [property: JsonPropertyName("actors")] IReadOnlyList<string> Actors,
        [property: JsonConverter(typeof(Iso8601DurationConverter))][property: JsonPropertyName("length")] TimeSpan? Length,
        [property: JsonPropertyName("studio")] string Studio,
        [property: JsonPropertyName("label")] string Label,
        [property: JsonPropertyName("series")] string? Series,
        [property: JsonPropertyName("genres")] IReadOnlyList<string> Genres,
        [property: JsonPropertyName("samples")] IReadOnlyList<Uri> Samples,
        [property: JsonPropertyName("communityRating")] decimal? CommunityRating
    );

    public record MovieIndex(
        [property: JsonPropertyName("provider")] string Provider,
        [property: JsonPropertyName("detailPageUrl")] Uri DetailPageUrl,
        [property: JsonPropertyName("number")] string Number,
        [property: JsonPropertyName("title")] string Title,
        [property: JsonPropertyName("coverUrl")] Uri? CoverUrl,
        [property: JsonPropertyName("releaseDate")] DateTime? ReleaseDate
    );

    internal class Iso8601DurationConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return XmlConvert.ToTimeSpan(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(XmlConvert.ToString(value));
        }
    }
}
