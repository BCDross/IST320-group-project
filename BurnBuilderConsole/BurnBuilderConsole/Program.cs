﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
//using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BurnBuilderConsole.Models;
using MtgApiManager;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.SystemTextJson;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace BurnBuilderConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("********* Getting The Game Sets!! **********");
            await ProcessSets();
            Console.WriteLine("********* Getting The Game Cards! **********");
            await ProcessCards();
        }

        // Access Methods to get JSON data.
        private static async Task ProcessSets()
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
                    Console.WriteLine($"Set object in JSON form: {set}");

                    CardSet cardSet = JsonSerializer.Deserialize<CardSet>(set.ToString());

                    listOfSets.Add(cardSet);
                }

            }

            foreach (var set in listOfSets)
            {
                Console.WriteLine($"Set object from List: {set.Name}");
            }

            Console.WriteLine($"Total sets : {count}");
        }

        private static async Task ProcessCards()
        {
            int count = 0;
            List<Cards> listOfCards = new List<Cards>();

            // Set up RestClient and connect to the api over http.
            var client = new RestClient("https://api.magicthegathering.io/v1");
            client.UseSystemTextJson();
            var request = new RestRequest("cards", DataFormat.Json);

            IRestResponse response = client.Get<Cards>(request);

            // Break the JSON document into the root and its data elements. 
            using (JsonDocument document = JsonDocument.Parse(response.Content))
            {
                JsonElement root = document.RootElement;
                JsonElement cardsElement = root.GetProperty("cards");

                count = cardsElement.GetArrayLength();

                foreach (JsonElement card in cardsElement.EnumerateArray())
                {
                    Console.WriteLine($"Card object in JSON form: {card}");

                    Cards cards = JsonSerializer.Deserialize<Cards>(card.ToString());

                    listOfCards.Add(cards);
                }

            }
            // Display all the cards after they have been deserialized.
            foreach (var card in listOfCards)
            {
                Console.WriteLine($"Set object from List: {card.Name}");
            }

            Console.WriteLine($"Total cards : {count}");
        }
    }
}
