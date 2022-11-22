using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.Jav.Model
{
    public record Actor(
        [property: JsonPropertyName("provider")] string Provider,
        [property: JsonPropertyName("detailPageUrl")] Uri DetailPageUrl,
        [property: JsonPropertyName("avatarUrl")] Uri? AvatarUrl,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("aliases")] IReadOnlyList<string> Aliases,
        [property: JsonPropertyName("galleries")] IReadOnlyList<Uri> Galleries,
        [property: JsonPropertyName("birthday")] DateTime Birthday,
        [property: JsonPropertyName("bloodType")] string? BloodType,
        [property: JsonPropertyName("cupSize")] char? CupSize,
        [property: JsonPropertyName("debutDate")] DateTime? DebutDate,
        [property: JsonPropertyName("height")] int? Height,
        [property: JsonPropertyName("measurements")] string? Measurements,
        [property: JsonPropertyName("nationality")] string? Nationality,
        [property: JsonPropertyName("biography")] string? Biography
    );

    public record ActorIndex(
        [property: JsonPropertyName("provider")] string Provider,
        [property: JsonPropertyName("detailPageUrl")] Uri DetailPageUrl,
        [property: JsonPropertyName("avatarUrl")] Uri? AvatarUrl,
        [property: JsonPropertyName("name")] string Name
    );
}
