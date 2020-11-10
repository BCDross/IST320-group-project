using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
//using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
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
            //await ProcessApiSets();
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
                Console.WriteLine($"Set object from List: {set}");
            }


            //dynamic dObject = JObject.Parse(response.Content);
            //var setsList = new List<CardSet>();
            
            //foreach (var property in dObject.setsList)
            //{
            //    var set = property.Value;

            //    var SetModel = new CardSet
            //    {
            //        Code = set.code,
            //        Name = set.name,
            //        Type  = set.type,
            //        Booster = set.booster,
            //        ReleaseDate = set.releasedate,
            //        Block = set.block,
            //        OnlineOnly = set.onlineonly 
            //    };

            //    setsList.Add(SetModel);

            //    Console.WriteLine($"Name : {SetModel.Name}");
            //}
            
            //string stringResponse = response.Content.Normalize();

            //Console.WriteLine(stringResponse);

            //Set cardSets = JsonConvert.DeserializeObject<Set>(stringResponse,
            //    new JsonSerializerSettings());

            //Console.WriteLine(cardSets);
        }

        private static async Task ProcessApiSets()
        {
            var client = new RestClient("https://api.magicthegathering.io/v1");
            client.UseSystemTextJson();
            var request = new RestRequest("sets", DataFormat.Json);

            IRestResponse response = client.Get<CardSet>(request);

            Console.WriteLine("Response Data");
            Console.WriteLine(response.Content);
        }

        private static async Task ProcessCards()
        {
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/api.magicthegathering.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", "Burn Builder");

            //var stringTask = client.GetStringAsync("https://api.magicthegathering.io/v1/cards");

            ////CardService service = new CardService();
            //Exceptional<List<Card>> result = service.All();
            //if (result.IsSuccess)
            //{
            //    var value = result.Value;
            //}
            //else
            //{
            //    var exception = result.Exception;
            //}
            //Console.WriteLine(result.Value);
            //Console.WriteLine(result.Exception);

            //var asyncResult = await stringTask;

            //Console.WriteLine(asyncResult);
        }
    }
}
