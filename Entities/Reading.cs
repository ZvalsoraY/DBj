using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Reading
    {
        private int _id;
        private int _serviceId;
        private float _curValue;
        private DateTime _transDate;
        
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }

        public int ServiceId
        {
            get => _serviceId;
            set
            {
                _serviceId = value;
            }
        }
        public float CurValue
        {
            get => _curValue;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _curValue = value;
            }
        }
        public DateTime TransDate
        {
            get => _transDate;
            set
            {
                if (DateTime.Now.Year - value.Year > 150)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _transDate = value;
            }
        }
              
        public Reading(int id, int serviceId, float curValue, DateTime trunsDate)
        {
            Id = id;
            ServiceId = serviceId;
            CurValue = curValue;
            TransDate = trunsDate;
        }
        public Reading(int serviceId, float curValue, DateTime trunsDate)
            : this(0, serviceId, curValue, trunsDate)
        {
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Rate p = (Rate)obj;
                return (Id == p.Id);
            }
        }
    }
}
