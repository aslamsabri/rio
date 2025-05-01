using Ria.CustomerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Ria.customers.Simulator.Services
{
    internal class CustomerServiceClient
    {
        private static readonly HttpClient _client = new HttpClient();

        private static readonly string _baseUrl = "http://localhost:39418/customers";

        private static int _globalId = 1;

        private static readonly string[] FirstNames = {
            "Leia", "Sadie", "Jose", "Sara", "Frank",
            "Dewey", "Tomas", "Joel", "Lukas", "Carlos"
        };

        private static readonly string[] LastNames = {
            "Liberty", "Ray", "Harrison", "Ronan", "Drew",
            "Powell", "Larsen", "Chan", "Anderson", "Lane"
        };

        public async Task PostRandomCustomersAsync()
        {
            List<Customer> batch = CreateRandomCustomers();

            try
            {
                var response = await _client.PostAsJsonAsync(_baseUrl, batch);
                var result = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"POST /customers ({batch.Count}) => {(int)response.StatusCode}: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("POST error: " + ex.Message);
            }
        }

        public async Task GetCustomersAsync()
        {
            try
            {
                var response = await _client.GetAsync(_baseUrl);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"GET /customers => {(int)response.StatusCode}, length: {content.Length} chars");
            }
            catch (Exception ex)
            {
                Console.WriteLine("GET error: " + ex.Message);
            }
        }

        private List<Customer> CreateRandomCustomers()
        {
            List<Customer> list = new List<Customer>();
            Random rand = new Random();
            int count = rand.Next(2, 5);

            for (int i = 0; i < count; i++)
            {
                var cust = new Customer
                {
                    FirstName = FirstNames[rand.Next(FirstNames.Length)],
                    LastName = LastNames[rand.Next(LastNames.Length)],
                    Age = rand.Next(10, 91),
                    Id = Interlocked.Increment(ref _globalId)
                };

                list.Add(cust);
            }

            return list;
        }
    }
}


