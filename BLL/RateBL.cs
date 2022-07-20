using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;

namespace BLL
{
    public class RateBL : IRateBL
    {
        private readonly IRateDAO _rateDAO;
        public RateBL(IRateDAO rateDAO)
        {
            _rateDAO = rateDAO;
        }
        public IEnumerable<Rate> GetAll()
        {
            return _rateDAO.GetAll();
        }
        public void Add(Rate rate)
        {
            _rateDAO.Add(rate);
        }
        public void Edit(Rate rate)
        {

            _rateDAO.Edit(rate);
        }
        public void Delete(Rate rate)
        {
            _rateDAO.Delete(rate);
        }
    }
}
