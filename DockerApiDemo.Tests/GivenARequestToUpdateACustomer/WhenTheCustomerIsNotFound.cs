using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using DockerApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToUpdateACustomer
{
    public class WhenTheCustomerIsNotFound
    {
        private NotFoundResult _result;
        private Mock<ICustomersRepository> _customersRepository;
        private Customer _customer;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer
            {
                Id = 1,
                FirstName = "Customer",
                LastName = "One",
                Email = "c.one@test.com",
                Password = "Password1"
            };

            _customersRepository = new Mock<ICustomersRepository>();
            _customersRepository.Setup(mock => mock.Update(It.IsAny<Customer>())).Returns(false);

            var subject = new CustomersController(_customersRepository.Object);

            _result = subject.Update(_customer) as NotFoundResult;
        }

        [Test]
        public void ThenTheCustomerIsUpdatedThroughTheRepository()
        {
            _customersRepository.Verify(mock => mock.Update(It.Is<Customer>(x => x.Id == _customer.Id 
                                                                                 && x.FirstName == _customer.FirstName
                                                                                 && x.LastName == _customer.LastName
                                                                                 && x.Email == _customer.Email
                                                                                 && x.Password == _customer.Password)), Times.Once);
        }

        [Test]
        public void ThenANotFoundResponseIsReturned()
        {
            Assert.That(_result, Is.Not.Null);
            Assert.That(_result, Is.TypeOf<NotFoundResult>());
        }
    }
}
