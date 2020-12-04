using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace BurnBuilderConsole.Models
{
    // Needs to be named Cards to differentiate between the MTG SDK and our internal structures.
    [Table("Card")]
    public class Card
    {
        [Key]
        public int CardId { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("manaCost")]
        public string ManaCost { get; set; }
        [Column(TypeName = "decimal")]
        [JsonPropertyName("cmc")]
        public decimal Cmc { get; set; }
        [JsonIgnore]
        public string Colors { get; set; }
        [JsonIgnore]
        public string ColorIdentity { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonIgnore]
        public string Supertypes { get; set; }
        [JsonIgnore]
        public string Types { get; set; }
        [JsonIgnore]
        public string Subtypes { get; set; }
        [JsonPropertyName("rarity")]
        public string Rarity { get; set; }
        [JsonPropertyName("set")]
        public string Set { get; set; }
        [JsonPropertyName("setName")]
        public string SetName { get; set; }
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("artist")]
        public string Artist { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
        [JsonPropertyName("layout")]
        public string Layout { get; set; }
        [JsonPropertyName("multiverseid")]
        public int MultiverseID { get; set; }
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonIgnore]
        public string Rulings { get; set; }
        [JsonIgnore]
        public string ForeignNames { get; set; }
        [JsonIgnore]
        public string Printings { get; set; }
        [JsonPropertyName("originalText")]
        public string OriginalText { get; set; }
        [JsonPropertyName("originalType")]
        public string OriginalType { get; set; }
        [JsonIgnore]
        public string Legalities { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
