using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;

namespace BLL
{
    public class ReadingBL : IReadingBL
    {
        private readonly IReadingDAO _readingDAO;
        public ReadingBL(IReadingDAO readingDAO)
        {
            _readingDAO = readingDAO;
        }
        public IEnumerable<Reading> GetAll()
        {
            return _readingDAO.GetAll();
        }
        public void Add(Reading reading)
        {
            _readingDAO.Add(reading);
        }
        public void Edit(Reading reading)
        {

            _readingDAO.Edit(reading);
        }
        public void Delete(Reading reading)
        {
            _readingDAO.Delete(reading);
        }
    }
}
