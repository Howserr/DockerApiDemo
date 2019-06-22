using System.Collections.Generic;
using System.Linq;
using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToGetAllCustomers
{
    public class WhenThereAreCustomers
    {
        private Customer[] _customers;
        private OkObjectResult _result;

        [SetUp]
        public void SetUp()
        {
            _customers = new[]
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
            customersRepository.Setup(mock => mock.Get()).Returns(_customers);

            var subject = new CustomersController(customersRepository.Object);

            _result = subject.Get() as OkObjectResult;
        }

        [Test]
        public void ThenAnOkResponseIsReturned()
        {
            Assert.That(_result, Is.Not.Null);
            Assert.That(_result, Is.TypeOf<OkObjectResult>());
        }

        [Test]
        public void ThenAllTheCustomersAreReturned()
        {
            var resultCustomers = _result.Value as IEnumerable<Customer>;

            Assert.That(resultCustomers.Contains(_customers[0]));
            Assert.That(resultCustomers.Contains(_customers[1]));
            Assert.That(resultCustomers.Contains(_customers[2]));
        }
    }
}