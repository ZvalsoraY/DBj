using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;

namespace BLL
{
    public class ServiceBL : IServiceBL
    {
        private readonly IServiceDAO _serviceDAO;
        public ServiceBL(IServiceDAO serviceDAO)
        {
            _serviceDAO = serviceDAO;
        }
        public IEnumerable<Service> GetAll()
        {
            return _serviceDAO.GetAll();
        }
        public void Add(Service service)
        {
            _serviceDAO.Add(service);
        }
        public void Edit(Service service)
        {

            _serviceDAO.Edit(service);
        }
        public void Delete(Service service)
        {
            _serviceDAO.Delete(service);
        }
    }
}
