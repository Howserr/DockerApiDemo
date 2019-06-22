using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToDeleteACustomer
{
    public class WhenTheCustomerIsDeletedSuccessfully
    {
        private int _id;
        private NoContentResult _result;
        private Mock<ICustomersRepository> _customersRepository;

        [SetUp]
        public void SetUp()
        {
            _id = 1;
            _customersRepository = new Mock<ICustomersRepository>();
            _customersRepository.Setup(mock => mock.Delete(It.IsAny<int>())).Returns(true);

            var subject = new CustomersController(_customersRepository.Object);

            _result = subject.Delete(_id) as NoContentResult;
        }

        [Test]
        public void ThenTheCustomerIsDeletedThroughTheRepository()
        {
            _customersRepository.Verify(mock => mock.Delete(_id), Times.Once);
        }

        [Test]
        public void ThenANoContentResponseIsReturned()
        {
            Assert.That(_result, Is.Not.Null);
            Assert.That(_result, Is.TypeOf<NoContentResult>());
        }
    }
}
