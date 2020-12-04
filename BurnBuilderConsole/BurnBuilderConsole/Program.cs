using BurnBuilderConsole.Models;
using BurnBuilderConsole.DAL;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.IdentityModel.Tokens;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BurnBuilderConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", false, true).Build();

            Console.WriteLine("Getting the things... and putting them into the database.");
            Console.WriteLine("********* Getting The Game Sets!! **********");
            await ProcessSets(config);
            Console.WriteLine("********* Getting The Game Cards! **********");
            await ProcessCards(config);
            Console.WriteLine("Card Sets and Cards have been successfully import. Press any key to end application...");
            Console.ReadKey();
        }

        // Access Methods to get JSON data.
        private static async Task ProcessSets(IConfiguration config)
        {
            int count = 0;
            List<CardSet> listOfSets = new List<CardSet>();

            // Set up RestClient and connect to the api over http.
            var client = new RestClient("https://api.magicthegathering.io/v1");
            client.UseSystemTextJson();
            var request = new RestRequest("sets", DataFormat.Json);

            IRestResponse response = client.Get<CardSet>(request);

            //Console.WriteLine("Response Data");
            //Console.WriteLine(response.Content);

            using (JsonDocument document = JsonDocument.Parse(response.Content))
            {
                JsonElement root = document.RootElement;
                JsonElement setsElement = root.GetProperty("sets");

                count = setsElement.GetArrayLength();

                foreach (JsonElement set in setsElement.EnumerateArray())
                {
                    //Console.WriteLine($"Set object in JSON form: {set}");

                    CardSet cardSet = JsonSerializer.Deserialize<CardSet>(Convert.ToString(set));

                    listOfSets.Add(cardSet);
                }

            }

            Console.WriteLine($"Total sets : {count}");

            foreach (var set in listOfSets)
            {
                DALCardSet dCSet = new DALCardSet(config);
                CardSet cSet = new CardSet();
                cSet.Code = set.Code;
                cSet.Name = set.Name;
                cSet.Type = set.Type;
                cSet.Booster = "";
                cSet.ReleaseDate = set.ReleaseDate;
                cSet.Block = set.Block is null ? "" : set.Block;
                cSet.OnlineOnly = set.OnlineOnly;

                dCSet.InsertCardSet(cSet);

                Console.WriteLine($"Set {cSet.Name} saved to the database.");
            }
        }

        private static async Task ProcessCards(IConfiguration config)
        {
            int count = 0;
            List<Card> listOfCards = new List<Card>();

            // Set up RestClient and connect to the api over http.
            var client = new RestClient("https://api.magicthegathering.io/v1");
            client.UseSystemTextJson();
            var request = new RestRequest("cards", DataFormat.Json);

            IRestResponse response = client.Get<Card>(request);

            // Break the JSON document into the root and its data elements. 
            using (JsonDocument document = JsonDocument.Parse(response.Content))
            {
                JsonElement root = document.RootElement;
                JsonElement cardsElement = root.GetProperty("cards");

                count = cardsElement.GetArrayLength();

                foreach (JsonElement card in cardsElement.EnumerateArray())
                {
                    //Console.WriteLine($"Card object in JSON form: {card}");

                    Card cards = JsonSerializer.Deserialize<Card>(card.ToString());

                    listOfCards.Add(cards);
                }

            }

            Console.WriteLine($"Total cards : {count}");

            // Display all the cards after they have been deserialized.
            foreach (var card in listOfCards)
            {
                DALCard dC = new DALCard(config);
                Card c = new Card();
                c.Name = card.Name;
                c.ManaCost = card.ManaCost is null ? "" : card.ManaCost;
                c.Cmc = card.Cmc;
                c.Colors = card.Colors is null ? "" : card.Colors;
                c.ColorIdentity = card.ColorIdentity is null ? "" : card.ColorIdentity;
                c.Type = card.Type;
                c.Supertypes = card.Supertypes is null ? "" : card.Supertypes;
                c.Types = card.Types is null ? "" : card.Types;
                c.Subtypes = card.Subtypes is null ? "" : card.Subtypes;
                c.Rarity = card.Rarity;
                c.Set = card.Set;
                c.SetName = card.SetName;
                c.Text = card.Text is null ? "" : card.Text;
                c.Artist = card.Artist;
                c.Number = card.Number;
                c.Layout = card.Layout;
                c.MultiverseID = card.MultiverseID;
                c.ImageUrl = card.ImageUrl is null ? "" : card.ImageUrl;
                c.Rulings = card.Rulings is null ? "" : card.Rulings;
                c.ForeignNames = card.ForeignNames is null ? "" : card.ForeignNames;
                c.Printings = card.Printings is null ? "" : card.Printings;
                c.OriginalText = card.OriginalText is null ? "" : card.OriginalText;
                c.OriginalType = card.OriginalType is null ? "" : card.OriginalType;
                c.Legalities = card.Legalities is null ? "" : card.Legalities;
                c.Id = card.Id;

                dC.InsertCard(c);

                Console.WriteLine($"Card {card.Name} saved to the database.");
            }

            Console.WriteLine($"Total cards : {count}");
        }
    }
}
