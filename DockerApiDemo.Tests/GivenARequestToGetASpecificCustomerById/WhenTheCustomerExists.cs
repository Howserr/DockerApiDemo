using System.Collections.Generic;
using System.Linq;
using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using DockerApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToGetASpecificCustomerById
{
    public class WhenTheCustomerExists
    {
        private OkObjectResult _result;
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
                Password = "test1"
            };

            var customersRepository = new Mock<ICustomersRepository>();
            customersRepository.Setup(mock => mock.Get(1)).Returns(_customer);

            var subject = new CustomersController(customersRepository.Object);

            _result = subject.Get(1) as OkObjectResult;
        }

        [Test]
        public void ThenAnOkResponseIsReturned()
        {
            Assert.That(_result, Is.Not.Null);
            Assert.That(_result, Is.TypeOf<OkObjectResult>());
            Assert.That(_result.Value, Is.TypeOf<Customer>());
        }

        [Test]
        public void ThenTheCustomerIsReturned()
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
