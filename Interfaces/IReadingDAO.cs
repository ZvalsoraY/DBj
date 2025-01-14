﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    public interface IReadingDAO
    {
        IEnumerable<Reading> GetAll();
        void Add(Reading reading);
        void Edit(Reading reading);
        void Delete(Reading reading);

        List<Reading> GetServicesReadings(Service service);
    }
}
