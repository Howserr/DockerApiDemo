using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToDeleteACustomer
{
    public class WhenTheCustomerIsDeletedSuccessfully
    {
        private NoContentResult _result;

        [SetUp]
        public void SetUp()
        {
            var customerRepository = new Mock<ICustomersRepository>();
            customerRepository.Setup(mock => mock.Delete(It.IsAny<int>())).Returns(true);

            var subject = new CustomersController(customerRepository.Object);

            _result = subject.Delete(1) as NoContentResult;
        }

        [Test]
        public void ThenANoContentResponseIsReturned()
        {
            Assert.That(_result, Is.Not.Null);
            Assert.That(_result, Is.TypeOf<NoContentResult>());
        }
    }
}
