using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BurnBuilderConsole.Models
{
    // Needs to be named Cards to differentiate between the MTG SDK and our internal structures.
    class Cards
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("manaCost")]
        public string ManaCost { get; set; }
        
        [JsonPropertyName("cmc")]
        public decimal Cmc { get; set; }
        
        [JsonPropertyName("colors")]
        public List<object> Colors { get; set; }
        
        [JsonPropertyName("colorIdentity")]
        public List<object> ColorIdentity { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("supertypes")]
        public List<object> Supertypes { get; set; }
        
        [JsonPropertyName("types")]
        public List<object> Types { get; set; }
        
        [JsonPropertyName("subtypes")]
        public List<object> Subtypes { get; set; }
        
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
        public List<object> Rulings { get; set; }
        
        [JsonPropertyName("foreignNames")]
        public List<object> ForeignNames { get; set; }
        
        [JsonPropertyName("printings")]
        public List<object> Printings { get; set; }

        [JsonPropertyName("originalText")]
        public string OriginalText { get; set; }

        [JsonPropertyName("originalType")]
        public string OriginalType { get; set; }

        [JsonPropertyName("legalities")]
        public List<object> Legalities { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
