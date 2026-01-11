namespace CManager.Business
{
    public interface ICustomerRepository
    {
        void SaveToFile(List<Customer> customers);
        List<Customer> GetFromFile();
    }
}