using System.Linq;
using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToGetAllCustomers
{
    public class WhenThereAreNoCustomers
    {
        [Test]
        public void ThenAnEmptyListIsReturned()
        {
            var customersRepository = new Mock<ICustomersRepository>();
            customersRepository.Setup(mock => mock.Get()).Returns(new Customer[]{});

            var subject = new CustomersController(customersRepository.Object);

            var result = subject.Get().Value.ToList();

            Assert.That(result.Count, Is.EqualTo(0));
        }
    }
}