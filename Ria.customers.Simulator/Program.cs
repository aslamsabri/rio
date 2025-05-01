// See https://aka.ms/new-console-template for more information
using Ria.customers.Simulator.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ria.CustomerAPI.Models;
using Microsoft.Extensions.Hosting;



var builder = Host.CreateApplicationBuilder(args);


builder.Services.AddSingleton<HttpClient>();
builder.Services.AddTransient<CustomerServiceClient>();
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var options = config.GetSection("CustomerSimulator").Get<CustomerSimulatorOptions>();

HttpClient client = new HttpClient();
var service = new CustomerServiceClient(client, Microsoft.Extensions.Options.Options.Create(options));

Console.WriteLine("Simulator Started!");

    List<Task> tasks = new List<Task>();

    for (int i = 0; i < 5; i++)
    {
        tasks.Add(Task.Run(() => service.PostRandomCustomersAsync()));

        tasks.Add(Task.Run(() => service.GetCustomersAsync()));

        await Task.Delay(100); // Simulate real-world gaps
    }

    await Task.WhenAll(tasks);

Console.WriteLine("Simulator Finished!");
