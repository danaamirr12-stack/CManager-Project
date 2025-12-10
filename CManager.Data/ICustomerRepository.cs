using CManager.Business;

namespace CManager.Data
{
    public interface ICustomerRepository
    {
        void SaveToFile(List<Customer> customers);
        List<Customer> GetFromFile();
    }
}
