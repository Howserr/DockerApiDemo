using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using DockerApiDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToAddACustomer
{
    public class WhenTheCustomerIsAddedSuccessfully
    {
        private Customer _customer;
        private CreatedAtActionResult _result;
        private Customer _resultCustomer;
        private Mock<ICustomersRepository> _customerRepository;

        [SetUp]
        public void SetUp()
        {
            _customer = new Customer
            {
                FirstName = "New",
                LastName = "Customer",
                Email = "customer@test.com",
                Password = "Password1"
            };

            _customerRepository = new Mock<ICustomersRepository>();
            _customerRepository.Setup(mock => mock.Create(It.IsAny<Customer>())).Callback(() => _customer.Id = 1);

            var subject = new CustomersController(_customerRepository.Object);

            _result = subject.Create(_customer) as CreatedAtActionResult;
            _resultCustomer = _result.Value as Customer;
        }

        [Test]
        public void ThenACreatedResponseIsReturned()
        {
            Assert.That(_result, Is.Not.Null);
            Assert.That(_result, Is.TypeOf<CreatedAtActionResult>());
            Assert.That(_resultCustomer, Is.TypeOf<Customer>());
        }

        [Test]
        public void ThenTheResponseHasTheCorrectAction()
        {
            Assert.That(_result.ActionName, Is.EqualTo("GetById"));
        }

        [Test]
        public void ThenTheResponseHasTheCorrectCustomer()
        {
            Assert.That(_resultCustomer.Id, Is.EqualTo(_customer.Id));
            Assert.That(_resultCustomer.FirstName, Is.EqualTo(_customer.FirstName));
            Assert.That(_resultCustomer.LastName, Is.EqualTo(_customer.LastName));
            Assert.That(_resultCustomer.Email, Is.EqualTo(_customer.Email));
            Assert.That(_resultCustomer.Password, Is.EqualTo(_customer.Password));
        }
    }
}
