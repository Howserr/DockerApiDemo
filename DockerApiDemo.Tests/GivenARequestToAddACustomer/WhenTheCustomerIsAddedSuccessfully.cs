using DockerApiDemo.Controllers;
using DockerApiDemo.Data;
using DockerApiDemo.Models;
using Moq;
using NUnit.Framework;

namespace DockerApiDemo.Tests.GivenARequestToAddACustomer
{
    public class WhenTheCustomerIsAddedSuccessfully
    {
        [Test]
        public void ThenACreatedResponseIsReturned()
        {
            var subject = new CustomersController(new Mock<ICustomersRepository>().Object);

            var result = subject.Create(new Customer
            {
                FirstName = "New",
                LastName = "Customer",
                Email = "customer@test.com",
                Password = "Password1"
            });
        }
    }
}
