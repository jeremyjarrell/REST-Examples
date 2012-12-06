using System;
using Model;
using RestSharp;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://localhost:88/api/");

            //GET prospects
            var request = new RestRequest("prospects", Method.GET);
            var response = client.Execute(request);
            DisplayResponse(response);

            //GET prospects/3
            request = new RestRequest("prospects/3", Method.GET);
            response = client.Execute(request);
            DisplayResponse(response);

            //POST prospects
            request = new RestRequest("prospects", Method.POST);
            request.AddObject(new Prospect {Name = "New Prospect"});
            response = client.Execute(request);
            DisplayResponse(response);

            //PUT prospects/5
            request = new RestRequest("prospects/1", Method.PUT);
            request.AddBody("Updated Prospect 1");
            response = client.Execute(request);
            DisplayResponse(response);

            //DELETE prospects/5
            request = new RestRequest("prospects/1", Method.DELETE);
            response = client.Execute(request);
            DisplayResponse(response);
        }

        private static void DisplayResponse(IRestResponse response)
        {
            Console.WriteLine(response.Content);
            Console.WriteLine(string.Format("{0} - {1}",(int)response.StatusCode, response.StatusDescription));
            Console.WriteLine();
        }
    }
}
