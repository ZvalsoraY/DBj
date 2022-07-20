using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;


namespace BLL
{
    public class CounterBL : ICounterBL
    {
        private readonly ICounterDAO _counterDAO;
        public CounterBL(ICounterDAO rewardDAO)
        {
            _counterDAO = rewardDAO;
        }
        public IEnumerable<Counter> GetAll()
        {
            return _counterDAO.GetAll();
        }
        public void Add(Counter counter)
        {
            _counterDAO.Add(counter);
        }
        public void Edit(Counter counter)
        {

            _counterDAO.Edit(counter);
        }
        public void Delete(Counter counter)
        {
            _counterDAO.Delete(counter);
        }
    }
}
