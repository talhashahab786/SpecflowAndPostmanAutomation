using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace RestSharpExample2
{
    class Program2
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://simple-books-api.glitch.me/");
            var request = new RestRequest("/books", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine("Response Content:");
            Console.WriteLine(response.Content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("[PASSED] Status code is 200");
                JArray jsonArray = JArray.Parse(response.Content);
                String name = jsonArray[0]["name"].ToString();
                String type = jsonArray[1]["type"].ToString();
                Console.WriteLine("Response body should contain name: 'The Russian'");
                Trace.Assert(name.Equals("The Russian"), "[FAILED] Response body should contain name: 'The Russian'");
                Console.WriteLine("[PASSED] Response body should contain name: 'The Russian'");
                Console.WriteLine("Response body should contain type: 'non-fiction'");
                Trace.Assert(type.Equals("non-fiction"), "[FAILED] Response body should contain type: 'non-fiction'");
                Console.WriteLine("[PASSED] Response body should contain type: 'non-fiction'");
            }
            else
            {
                Console.WriteLine("Error: " + response.ErrorMessage);
                Console.WriteLine("Status code is NOT 200");
            }
        }

    
    }
}