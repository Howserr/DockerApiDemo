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
            var customers = new[]
            {
                new Customer
                {
                    FirstName = "Max",
                    LastName = "Verstappen",
                    Email = "m.verstappen@redbull.com",
                    Password = "No1R4cer"
                },
                new Customer
                {
                    FirstName = "Daniel",
                    LastName = "Ricciardo",
                    Email = "d.ricciardo@renault.com",
                    Password = "b1gSM1L35"
                },
                new Customer
                {
                    FirstName = "Kimi",
                    LastName = "Raikkonen",
                    Email = "k.raikkonen@alfaromeo.com",
                    Password = "1W4SHaving4!*&$"
                }
            };

            var customersRepository = new Mock<ICustomersRepository>();
            customersRepository.Setup(mock => mock.Get()).Returns(customers);

            var subject = new CustomersController(customersRepository.Object);

            var result = subject.Get().Value.ToList();

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.Contains(customers[0]));
            Assert.That(result.Contains(customers[1]));
            Assert.That(result.Contains(customers[2]));
        }
    }
}