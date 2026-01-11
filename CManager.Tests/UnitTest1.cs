using CManager.Business;
using Moq;

namespace CManager.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void GetAllCustomers_ReturnsCustomerList()
        {
            var mockRepository = new Mock<ICustomerRepository>();

            List<Customer> testKunder = new List<Customer>();
            testKunder.Add(new Customer { FirstName = "Anna", Email = "anna@test.se" });

            mockRepository.Setup(x => x.GetFromFile()).Returns(testKunder);

            CustomerService service = new CustomerService(mockRepository.Object);

            List<Customer> resultat = service.GetAllCustomers();

            Assert.Equal(1, resultat.Count);
        }
    }
}