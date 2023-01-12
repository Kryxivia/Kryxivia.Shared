using Kryxivia.Shared.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Kryxivia.Shared.Types
{
    public class OpenSeaMetadata
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("image")]
        [JsonPropertyName("image")]
        public string ImageUrl { get; set; }

        [JsonProperty("external_url")]
        [JsonPropertyName("external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty("youtube_url")]
        [JsonPropertyName("youtube_url")]
        public string YoutubeUrl { get; set; }

        public List<IAttribute> Attributes { get; set; } = new List<IAttribute>();
    }

    public interface IAttribute
    {
        string TraitType { get; set; }
        object Value { get; set; }
    }

    public class SimpleOpenSeaAttribute : IAttribute
    {
        [JsonProperty("trait_type")]
        [JsonPropertyName("trait_type")]
        public string TraitType { get; set; }
        public object Value { get; set; }
    }

    public class OpenSeaAttribute : IAttribute
    {
        [JsonProperty("display_type")]
        [JsonPropertyName("display_type")]
        [Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        public DisplayTypeEnum DisplayType { get; set; }

        [JsonProperty("trait_type")]
        [JsonPropertyName("trait_type")]
        public string TraitType { get; set; }
        public object Value { get; set; }
    }

}
