using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    public interface IReadingBL
    {
        public IEnumerable<Reading> GetAll();
        public void Add(Reading reading);
        public void Edit(Reading reading);
        public void Delete(Reading reading);
    }
}
