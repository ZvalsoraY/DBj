using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    public interface ICounterDAO
    {
        IEnumerable<Counter> GetAll();
        void Add(Counter counter);
        void Edit(Counter counter);
        void Delete(Counter counter);
    }
}
