using System.Collections.Generic;

namespace DockerApiDemo.Data
{
    public interface ICustomersRepository
    {
        IEnumerable<string> Get();
    }

    public class CustomersRepository : ICustomersRepository
    {
        public IEnumerable<string> Get()
        {
            throw new System.NotImplementedException();
        }
    }
}