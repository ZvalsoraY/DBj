using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    public interface IServiceDAO
    {
        IEnumerable<Service> GetAll();
        void Add(Service service);
        void Edit(Service service);
        void Delete(Service service);
        Service GetServiceById(int id);
    }
}
