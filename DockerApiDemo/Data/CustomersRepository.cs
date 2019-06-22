using System.Collections.Generic;

namespace DockerApiDemo.Data
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> Get();
    }

    public class CustomersRepository : ICustomersRepository
    {
        public IEnumerable<Customer> Get()
        {
            return new Customer[]
            {
                new Customer
                {
                    FirstName = "Max",
                    LastName = "Verstappen",
                    Email = "m.verstappen@redbull.com",
                    Password = "No1R4cer"
                },
                new Customer
                {
                    FirstName = "Daniel",
                    LastName = "Ricciardo",
                    Email = "d.ricciardo@renault.com",
                    Password = "b1gSM1L35"
                },
                new Customer
                {
                    FirstName = "Kimi",
                    LastName = "Raikkonen",
                    Email = "k.raikkonen@alfaromeo.com",
                    Password = "1W4SHaving4!*&$"
                }
            };
        }
    }

    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}