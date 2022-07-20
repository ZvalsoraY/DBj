using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    public class IServiceDAO
    {
        public IEnumerable<Service> GetAll();
        public void Add(Service service);
        public void Edit(Service service);
        public void Delete(Service service);
    }
}
