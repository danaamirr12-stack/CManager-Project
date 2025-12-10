

namespace CManager.Business
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository repository;
        private List<Customer> customers;

        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
            customers = repository.GetFromFile();
        }

        public void CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city)
        {
            Customer customer = new Customer
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city
            };

            customers.Add(customer);
            repository.SaveToFile(customers);
        }

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer GetCustomerByEmail(string email)
        {
            foreach (Customer customer in customers)
            {
                if (customer.Email == email)
                {
                    return customer;
                }
            }
            return null;
        }

        public void DeleteCustomer(string email)
        {
            Customer customer = GetCustomerByEmail(email);
            if (customer != null)
            {
                customers.Remove(customer);
                repository.SaveToFile(customers);
            }
        }
    }
}