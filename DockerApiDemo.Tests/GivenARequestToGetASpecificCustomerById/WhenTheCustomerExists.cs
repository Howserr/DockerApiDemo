using System.Linq;
using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToGetASpecificCustomerById
{
    public class WhenTheCustomerExists
    {
        [Test]
        public void ThenAllTheCustomersAreReturned()
        {
            var customer = new Customer
            {
                Id = 1,
                FirstName = "Customer",
                LastName = "One",
                Email = "c.one@test.com",
                Password = "test1"
            };

            var customersRepository = new Mock<ICustomersRepository>();
            customersRepository.Setup(mock => mock.Get(1)).Returns(customer);

            var subject = new CustomersController(customersRepository.Object);

            var result = subject.Get(1).Value;

            Assert.That(result.Id, Is.EqualTo(customer.Id));
            Assert.That(result.FirstName, Is.EqualTo(customer.FirstName));
            Assert.That(result.LastName, Is.EqualTo(customer.LastName));
            Assert.That(result.Email, Is.EqualTo(customer.Email));
            Assert.That(result.Password, Is.EqualTo(customer.Password));
        }
    }
}
