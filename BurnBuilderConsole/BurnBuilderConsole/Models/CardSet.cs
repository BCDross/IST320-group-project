using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Transactions;
using MtgApiManager.Lib.Dto;
using MtgApiManager.Lib.Model;

namespace BurnBuilderConsole.Models
{
   public class CardSet
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("booster")]
        public List<object> booster { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("block")]
        public string Block { get; set; }

        [JsonPropertyName("onlineOnly")]
        public bool OnlineOnly { get; set; }

    }
}
