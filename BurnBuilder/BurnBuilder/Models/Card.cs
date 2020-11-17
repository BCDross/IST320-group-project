using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace BurnBuilder.Models
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
        
        [JsonPropertyName("colors")]
        public string Colors { get; set; }
        
        [JsonPropertyName("colorIdentity")]
        public string ColorIdentity { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("supertypes")]
        public string Supertypes { get; set; }
        
        [JsonPropertyName("types")]
        public string Types { get; set; }
        
        [JsonPropertyName("subtypes")]
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
        
        [JsonPropertyName("rulings")]
        public string Rulings { get; set; }
        
        [JsonPropertyName("foreignNames")]
        public string ForeignNames { get; set; }
        
        [JsonPropertyName("printings")]
        public string Printings { get; set; }

        [JsonPropertyName("originalText")]
        public string OriginalText { get; set; }

        [JsonPropertyName("originalType")]
        public string OriginalType { get; set; }

        [JsonPropertyName("legalities")]
        public string Legalities { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
