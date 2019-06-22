using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using DockerApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToGetASpecificCustomerById
{
    public class WhenTheCustomerDoesNotExist
    {
        [Test]
        public void ThenANotFoundResponseIsReturned()
        {
            var customersRepository = new Mock<ICustomersRepository>();
            customersRepository.Setup(mock => mock.GetById(1)).Returns(default(Customer));

            var subject = new CustomersController(customersRepository.Object);

            var result = subject.GetById(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}
