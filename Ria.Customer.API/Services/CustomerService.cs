using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Ria.CustomerAPI.Models;

namespace Ria.CustomerAPI.Services
{
    public class CustomerService
    {
        private readonly string _filePath = "Data/customers.json";
        private static readonly object _fileLock = new object();

        private readonly List<Customer> _customers;

        public CustomerService()
        {
            _customers = GetCustomers();
        }

        public IEnumerable<Customer> GetAll() => _customers;

        public List<string> InsertCustomers(List<Customer> newCustomers)
        {
            List<string> errors = new();

            foreach (var customer in newCustomers)
            {
                if (string.IsNullOrWhiteSpace(customer.FirstName) ||
                    string.IsNullOrWhiteSpace(customer.LastName) ||
                    customer.Age <= 0 || customer.Id <= 0)
                {
                    errors.Add($"Customer {customer.Id} is missing fields.");

                    continue;
                }

                if (customer.Age < 18)
                {
                    errors.Add($"Customer {customer.Id} is underage.");
                    continue;
                }
                if (_customers.Count>0) {
                    if (_customers.Any(c => c != null && c.Id == customer.Id))
                    {
                        errors.Add($"Customer ID {customer.Id} already exists.");
                        continue;
                    }
                }
                InsertCustomerSorted(customer);
            }

            SaveCustomers();

            return errors;
        }

        private void InsertCustomerSorted(Customer customer)
        {
            int i = 0;
            while (i < _customers.Count)
            {
                var c = _customers[i];

                if (string.Compare(customer.LastName, c.LastName) < 0 ||
                   (customer.LastName == c.LastName && string.Compare(customer.FirstName, c.FirstName) < 0))
                    break;
                i++;
            }
            _customers.Insert(i, customer);
        }

        private void SaveCustomers()
        {
            lock (_fileLock)
            {
                Directory.CreateDirectory("Data");
                File.WriteAllText(_filePath, JsonSerializer.Serialize(_customers));
            }

        }

        private List<Customer> GetCustomers()
        {
            if (File.Exists(_filePath))
            {
                var jsonData = File.ReadAllText(_filePath);


                return JsonSerializer.Deserialize<List<Customer>>(jsonData) ?? new List<Customer>();
            }
            return new List<Customer>();
        }
    }
}
