using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BurnBuilderConsole.Models
{
    public class CardSet
    {
        [Key]
        public int CardSetId { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [DataType(DataType.Text)]
        [JsonPropertyName("booster")]
        public string Booster { get; set; }
        [DataType(DataType.Date)]
        [JsonPropertyName("releaseDate")]
        public DateTime ReleaseDate { get; set; }
        [JsonPropertyName("block")]
        public string Block { get; set; }
        [JsonPropertyName("onlineOnly")]
        public bool OnlineOnly { get; set; }
    }
}
