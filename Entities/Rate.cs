using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rate
    {
        private int _id;
        private string _name;
        private int _price;
        private DateTime _startData;
        private DateTime _endData;
        private int _serviceId;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 50)
                {
                    throw new ArgumentOutOfRangeException(nameof(Name), "Wrong Name.");
                }

                _name = value;
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _price = value;
            }
        }
        public DateTime StartData
        {
            get => _startData;
            set
            {
                if (value > _endData || DateTime.Now.Year - value.Year > 150)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _startData = value;
            }
        }
        public DateTime EndData
        {
            get => _endData;
            set
            {
                if (value < _startData || DateTime.Now.Year - value.Year > 150)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _endData = value;
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
        public Rate(int id, string name, int serviceId, int price, DateTime startData, DateTime endData)
        {
            Id = id;
            Name = name;
            ServiceId = serviceId;
            Price = price;
            StartData = startData;
            EndData = endData;
        }
        public Rate(string name, int serviceId, int price, DateTime startData, DateTime endData) 
            : this(0, name, serviceId, price, startData, endData)
        {
        }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
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
