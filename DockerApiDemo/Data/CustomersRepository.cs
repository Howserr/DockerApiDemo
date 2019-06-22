using System.Collections.Generic;
using System.Linq;

namespace DockerApiDemo.Data
{
    public interface ICustomersRepository
    {
        IEnumerable<Customer> Get();
        Customer Get(int id);
    }

    public class CustomersRepository : ICustomersRepository
    {
        private Customer[] _customers = new[]
        {
            new Customer
            {
                Id = 1,
                FirstName = "Max",
                LastName = "Verstappen",
                Email = "m.verstappen@redbull.com",
                Password = "No1R4cer"
            },
            new Customer
            {
                Id = 2,
                FirstName = "Daniel",
                LastName = "Ricciardo",
                Email = "d.ricciardo@renault.com",
                Password = "b1gSM1L35"
            },
            new Customer
            {
                Id = 3,
                FirstName = "Kimi",
                LastName = "Raikkonen",
                Email = "k.raikkonen@alfaromeo.com",
                Password = "1W4SHaving4!*&$"
            }
        };

        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        public Customer Get(int id)
        {
            return _customers.FirstOrDefault(customer => customer.Id == id);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}