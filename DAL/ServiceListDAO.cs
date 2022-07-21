using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Interfaces;

namespace DAL
{
    public class ServiceListDAO
    {
        private readonly IList<Service> _services = new List<Service>();

        public IEnumerable<Service> GetAll()
        {
            return _services.ToArray();
        }
        public void Add(Service service)
        {
            var maxId = _services.Count > 0 ? _services.Max(p => p.Id) : 0;
            service.Id = maxId + 1;
            _services.Add(service);
        }
        public void Edit(Service service)
        {
            var serviceFromList = _services.First(x => x.Id == service.Id);
            serviceFromList.Id = service.Id;
            serviceFromList.Name = service.Name;
        }
        public void Delete(Service service)
        {
            _services.Remove(service);
        }
    }
}
