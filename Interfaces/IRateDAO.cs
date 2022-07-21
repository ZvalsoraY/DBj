using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    public interface IRateDAO
    {
        IEnumerable<Rate> GetAll();
        void Add(Rate rate);
        void Edit(Rate rate);
        void Delete(Rate rate);
    }
}
