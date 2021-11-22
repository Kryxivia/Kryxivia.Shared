using Kryxivia.Shared.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kryxivia.Shared.Types
{
    public class OpenSeaMetadata
    {
        public string Name { get; set; }
        public string Description { get; set; }

        [JsonProperty("image")]
        public string ImageUrl { get; set; }

        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty("youtube_url")]
        public string YoutubeUrl { get; set; }

        public List<OpenSeaAttribute> Attributes { get; set; } = new List<OpenSeaAttribute>();
    }

    public class OpenSeaAttribute
    {
        [JsonProperty("display_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DisplayTypeEnum DisplayType { get; set; }

        [JsonProperty("trait_type")]
        public string TraitType { get; set; }

        public object Value { get; set; }
    }
}
