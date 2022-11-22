using System;
using System.Text.Json.Serialization;

namespace Jellyfin.Plugin.Jav.Model
{
    public record ResponseMessage<T>
    (
        [property: JsonPropertyName("error")] ErrorInfo Error,
        [property: JsonPropertyName("data")] T? Data
    );

    public record ErrorInfo
    (
        [property: JsonPropertyName("code")] int Code,
        [property: JsonPropertyName("message")] string Message
    );
}
