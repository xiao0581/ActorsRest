using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    public class work
    {
        private HttpClient client;
        private string URL = "https://actorrest.azurewebsites.net/api/actors"; // Update the URL accordingly

        public work()
        {
            client = new HttpClient();
        }
        public async Task<IEnumerable<Actor>> GetAllxClass(string url)
        {
       

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(URL);
                response.EnsureSuccessStatusCode();
                IEnumerable<Actor> list = await response.Content.ReadFromJsonAsync<IEnumerable<Actor>>();
                return list;
            }

        }
        public async Task<Actor> GetById(int id)
        {


            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(URL+"/"+id);
                response.EnsureSuccessStatusCode();
                   Actor actor = await response.Content.ReadFromJsonAsync<Actor>();
                return actor;
            }
            

        }
        public async Task PostxClass(Actor actor)
        {
            using (HttpClient client = new HttpClient())
            {
                var serializedIxClass = JsonContent.Create(actor);
                HttpResponseMessage response = await client.PostAsync(URL, serializedIxClass);
                response.EnsureSuccessStatusCode();
                
            }
        }

        public async Task doWork(string url)
        {
            IEnumerable<Actor> xClassList = await GetAllxClass(url);
            
            if (xClassList != null)
            {
                foreach (var item in xClassList)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            {
                Console.WriteLine("No items retrieved from the service.");
            }
        }
        public async Task doWork2(int id)
        {
           Actor actor = await GetById(id);

            if (actor != null)
            {
               
                    Console.WriteLine(actor.ToString());
                
            }
            else
            {
                Console.WriteLine("No items retrieved from the service.");
            }
        }

    }
}
