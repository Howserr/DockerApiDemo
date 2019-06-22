using System.Collections.Generic;
using System.Linq;
using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using DockerApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToGetAllCustomers
{
    public class WhenThereAreNoCustomers
    {
        private OkObjectResult _result;

        [SetUp]
        public void SetUp()
        {
            var customersRepository = new Mock<ICustomersRepository>();
            customersRepository.Setup(mock => mock.Get()).Returns(new Customer[] { });

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

            Assert.That(resultCustomers.Count, Is.EqualTo(0));
        }
    }
}