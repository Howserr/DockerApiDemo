using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToGetASpecificCustomerById
{
    public class WhenTheCustomerDoesNotExist
    {
        [Test]
        public void ThenA404ErrorIsReturned()
        {
            var customersRepository = new Mock<ICustomersRepository>();
            customersRepository.Setup(mock => mock.Get(1)).Returns(default(Customer));

            var subject = new CustomersController(customersRepository.Object);

            var result = subject.Get(1);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.TypeOf<NotFoundResult>());
        }
    }
}
