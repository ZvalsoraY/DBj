using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Interfaces;

namespace DAL
{
    public class CounterListDAO : ICounterDAO
    {
        private readonly IList<Counter> _counters = new List<Counter>();

        public IEnumerable<Counter> GetAll()
        {
            return _counters.ToArray();
        }
        public void Add(Counter counter)
        {
            var maxId = _counters.Count > 0 ? _counters.Max(p => p.Id) : 0;
            counter.Id = maxId + 1;

            _counters.Add(counter);
        }
        public void Edit(Counter counter)
        {
            var counterFromList = _counters.First(x => x.Id == counter.Id);
            counterFromList.Id = counter.Id;
            counterFromList.Name = counter.Name;
        }
        public void Delete(Counter counter)
        {
            _counters.Remove(counter);
        }
    }
}
