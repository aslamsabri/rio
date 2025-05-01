using Microsoft.Extensions.Options;
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
        private readonly HttpClient httpClient;
        private readonly string baseUrl;
        private readonly string[] firstNames;
        private readonly string[] lastNames;
        private int globalId;

        public CustomerServiceClient(HttpClient client, IOptions<CustomerSimulatorOptions> config)
        {
            httpClient = client;
            var options = config.Value;

            baseUrl = options.BaseUrl;
            firstNames = options.FirstNames;
            lastNames = options.LastNames;
            globalId = options.StartingId;
        }

        public async Task PostRandomCustomersAsync()
        {
            List<Customer> batch = CreateRandomCustomers();

            try
            {
                var response = await httpClient.PostAsJsonAsync(baseUrl, batch);
                var result = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"POST /customers ({batch.Count}) => {(int)response.StatusCode}: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] Post error: " + ex.Message);
            }
        }

        public async Task GetCustomersAsync()
        {
            try
            {
                var response = await httpClient.GetAsync(baseUrl);
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
                    FirstName = firstNames[rand.Next(firstNames.Length)],
                    LastName = lastNames[rand.Next(lastNames.Length)],
                    Age = rand.Next(10, 91),
                    Id = Interlocked.Increment(ref globalId)
                };

                list.Add(cust);
            }

            return list;
        }
    }
}


