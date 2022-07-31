using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Interfaces;

namespace DAL
{
    public class ReadingListDAO
    {
        private readonly IList<Reading> _readings = new List<Reading>();

        public IEnumerable<Reading> GetAll()
        {
            return _readings.ToArray();
        }
        public void Add(Reading reading)
        {
            var maxId = _readings.Count > 0 ? _readings.Max(p => p.Id) : 0;
            reading.Id = maxId + 1;
            _readings.Add(reading);
        }
        public void Edit(Reading reading)
        {
            var readingFromList = _readings.First(x => x.Id == reading.Id);
            readingFromList.Id = reading.Id;
            readingFromList.ServiceId = reading.ServiceId;
            readingFromList.CurValue = reading.CurValue;
            readingFromList.TransDate = reading.TransDate;
        }
        public void Delete(Reading reading)
        {
            _readings.Remove(reading);
        }
        public List<Reading> GetServicesReadings(Service service)
        {
            var servicesReadings = new List<Reading>();

            for (int i = 0; i < _readings.Count; i++)
            {
                if (_readings[i].Id == service.Id)
                {
                    servicesReadings.Add(_readings[i]);
                }

            }
            return servicesReadings;
        }
    }
}
