using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    public class ICounterBL
    {
        public IEnumerable<Counter> GetAll();
        public void Add(Counter counter);
        public void Edit(Counter counter);
        public void Delete(Counter counter);
    }
}
