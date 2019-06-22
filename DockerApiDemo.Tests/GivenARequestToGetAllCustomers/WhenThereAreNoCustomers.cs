using System.Collections.Generic;
using System.Linq;
using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using Microsoft.AspNetCore.Mvc;
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

            var result = subject.Get() as OkObjectResult;

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<OkObjectResult>());

            var resultCustomers = result.Value as IEnumerable<Customer>;

            Assert.That(resultCustomers.Count, Is.EqualTo(0));
        }
    }
}