namespace CManager.Business
{
    public interface ICustomerService
    {
        void CreateCustomer(string firstName, string lastName, string email, string phoneNumber, string streetAddress, string postalCode, string city);
        List<Customer> GetAllCustomers();
        Customer GetCustomerByEmail(string email);
        void DeleteCustomer(string email);
    }
}
