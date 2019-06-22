using System.Collections.Generic;
using System.Linq;
using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToGetAllCustomers
{
    public class WhenThereAreCustomers
    {
        [Test]
        public void ThenAllTheCustomersAreReturned()
        {
            var customersRepository = new Mock<ICustomersRepository>();
            customersRepository.Setup(mock => mock.Get()).Returns(new[] {"Max", "Daniel", "Kimi"});

            var subject = new CustomersController(customersRepository.Object);

            var result = subject.Get().Value.ToList();

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.Contains("Max"));
            Assert.That(result.Contains("Daniel"));
            Assert.That(result.Contains("Kimi"));
        }
    }
}