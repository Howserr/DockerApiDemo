using System.Collections.Generic;
using System.Linq;
using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using DockerApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToUpdateACustomer
{
    public class WhenTheCustomerIsUpdateSuccessfully
    {
        private Customer _customer;
        private OkObjectResult _result;
        private Mock<ICustomersRepository> _customersRepository;

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
            _customersRepository.Setup(mock => mock.Update(It.IsAny<Customer>())).Returns(true);

            var subject = new CustomersController(_customersRepository.Object);

            _result = subject.Update(_customer) as OkObjectResult;
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
        public void ThenAnOkResponseIsReturned()
        {
            Assert.That(_result, Is.Not.Null);
            Assert.That(_result, Is.TypeOf<OkObjectResult>());
            Assert.That(_result.Value, Is.TypeOf<Customer>());
        }

        [Test]
        public void ThenTheUpdatedCustomerIsReturned()
        {
            var resultCustomer = _result.Value as Customer;

            Assert.That(resultCustomer.Id, Is.EqualTo(_customer.Id));
            Assert.That(resultCustomer.FirstName, Is.EqualTo(_customer.FirstName));
            Assert.That(resultCustomer.LastName, Is.EqualTo(_customer.LastName));
            Assert.That(resultCustomer.Email, Is.EqualTo(_customer.Email));
            Assert.That(resultCustomer.Password, Is.EqualTo(_customer.Password));
        }
    }
}
