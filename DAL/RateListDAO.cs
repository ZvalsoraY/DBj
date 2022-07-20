using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Interfaces;

namespace DAL
{
    public class RateListDAO : IRateDAO
    {
        private readonly IList<Rate> _rates = new List<Rate>();

        public IEnumerable<Rate> GetAll()
        {
            return _rates.ToArray();
        }
        public void Add(Rate rate)
        {
            var maxId = _rates.Count > 0 ? _rates.Max(p => p.Id) : 0;
            rate.Id = maxId + 1;

            _rates.Add(rate);
        }
        public void Edit(Rate rate)
        {
            var rateFromList = _rates.First(x => x.Id == rate.Id);
            rateFromList.Id = rate.Id;
            rateFromList.Name = rate.Name;
            rateFromList.ServiceId = rate.ServiceId;
            rateFromList.Price = rate.Price;
            rateFromList.StartData = rate.StartData;
            rateFromList.EndData = rate.EndData;
        }
        public void Delete(Rate rate)
        {
            _rates.Remove(rate);
        }
    }
}
