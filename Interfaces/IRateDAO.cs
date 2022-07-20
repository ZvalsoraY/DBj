﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Interfaces
{
    internal class IRateDAO
    {
        public IEnumerable<Rate> GetAll();
        public void Add(Rate rate);
        public void Edit(Rate rate);
        public void Delete(Rate rate);
    }
}
