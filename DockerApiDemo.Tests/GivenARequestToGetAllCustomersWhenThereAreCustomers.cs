using System.Linq;
using DockerApiDemo.Controllers;
using NUnit.Framework;

namespace DockerApiDemo.Tests
{
    public class GivenARequestToGetAllCustomersWhenThereAreCustomers
    {
        [Test]
        public void ThenAllTheCustomersAreReturned()
        {
            var subject = new CustomersController();

            var result = subject.Get().Value.ToList();

            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result.Contains("Max"));
            Assert.That(result.Contains("Daniel"));
            Assert.That(result.Contains("Kimi"));
        }
    }
}