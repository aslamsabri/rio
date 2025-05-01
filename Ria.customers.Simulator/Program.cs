// See https://aka.ms/new-console-template for more information
using Ria.customers.Simulator.Services;

Console.WriteLine("Simulator Started!");


    CustomerServiceClient service = new CustomerServiceClient();
    List<Task> tasks = new List<Task>();

    for (int i = 0; i < 5; i++)
    {
        tasks.Add(Task.Run(() => service.PostRandomCustomersAsync()));

        tasks.Add(Task.Run(() => service.GetCustomersAsync()));

        await Task.Delay(100); // Simulate real-world gaps
    }

    await Task.WhenAll(tasks);

Console.WriteLine("Simulator Finished!");
