using CManager.Business;
using System.Text.Json;

namespace CManager.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private string filePath = "customers.json";

        public void SaveToFile(List<Customer> customers)
        {
            string json = JsonSerializer.Serialize(customers);
            File.WriteAllText(filePath, json);
        }

        public List<Customer> GetFromFile()
        {
            if (!File.Exists(filePath))
            {
                return new List<Customer>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(json))
            {
                return new List<Customer>();
            }

            List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(json);

            if (customers == null)
            {
                return new List<Customer>();
            }

            return customers;
        }
    }
}
// Använde AI här för att få JSON-läsningen att funka och fixa felhanteringen.