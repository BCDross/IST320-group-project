using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;
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

        // Create the HTTP Client to reach out and access the api.
        //private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            

            await ProcessSets();
            Console.WriteLine("******************************************");
            Console.WriteLine("********* This is a new method! **********");
            Console.WriteLine("******************************************");

            //await ProcessApiSets();

        }

        // Access Methods to get JSON data.
        private static async Task ProcessSets()
        {
            // HTTP Call headers
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/api.magicthegathering.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", "Burn Builder");

            var client = new RestClient("https://api.magicthegathering.io/v1");
            client.UseSystemTextJson();
            var request = new RestRequest("sets", DataFormat.Json);

            IRestResponse response = client.Get<CardSet>(request);

            Console.WriteLine("Response Data");
            Console.WriteLine(response.Content);

            Set cardSets = JsonSerializer.Deserialize<Set>(response.Content, new JsonSerializerOptions {AllowTrailingCommas = true});

            foreach (var cardSet in cardSets)
            {
                Console.WriteLine(cardSet.Name);
            }

            // This is the api uri to call and get data from API.
            //var streamTask = client.GetStreamAsync("https://api.magicthegathering.io/v1/sets");
            // Deserialize the data Stream from the API.
            //var sets = await JsonSerializer.DeserializeAsync<Sets>(await streamTask);

            //CardSets cardSets = JsonSerializer.Deserialize<Sets(response)

            //// Set up the service call, and allow for error gathering.
            //SetService service = new SetService();
            //Exceptional<List<Set>> result = service.All();
            //if (result.IsSuccess)
            //{
            //    var value = result.Value;
            //}
            //else
            //{
            //    var exception = result.Exception;
            //}
            //// If needed for exception.
            //Console.WriteLine(result.Value);
            //Console.WriteLine(result.Exception);

            // save the call data to a variable when returned.
            //foreach (var set in sets)
            //{
            //    Console.WriteLine(set.Name);
            //}
        }

        private static async Task ProcessApiSets()
        {
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("User-Agent", "Burn Builder");

            //var stringTask = client.GetStringAsync("https://api.magicthegathering.io/v1/sets");

            //string setJson = stringTask.ToString();

            

            //CardService service = new CardService();
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

        private static async Task ProcessCards()
        {
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/api.magicthegathering.v3+json"));
            //client.DefaultRequestHeaders.Add("User-Agent", "Burn Builder");

            //var stringTask = client.GetStringAsync("https://api.magicthegathering.io/v1/cards");

            //CardService service = new CardService();
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
