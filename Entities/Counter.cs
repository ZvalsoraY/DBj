using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Counter
    {
        private int _id;
        private string _name;
        private int _serviceId;
        private int _serialNumber;
        private int _capacity;
        private int _decimalCapacity;
        private float _initialValue;
        private DateTime _createData;

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
        public int ServiceId
        {
            get => _serviceId;
            set
            {
                _serviceId = value;
            }
        }
        public int SerialNumber
        {
            get => _serialNumber;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _serialNumber = value;
            }
        }
        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _capacity = value;
            }
        }
        public int DecimalCapacity
        {
            get => _decimalCapacity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _decimalCapacity = value;
            }
        }
        public float InitialValue
        {
            get => _initialValue;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _initialValue = value;
            }
        }
        public DateTime CreateData
        {
            get => _createData;
            set
            {
                if (DateTime.Now.Year - value.Year > 150)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _createData = value;
            }
        }
        public Counter(int id, string name, int serviceId, int serialNumber, int capacity, int decimalCapacity, float initialValue, DateTime createData)
        {
            Id = id;
            Name = name;
            ServiceId = serviceId;
            SerialNumber = serialNumber;
            Capacity = capacity;
            DecimalCapacity = decimalCapacity;
            InitialValue = initialValue;
            CreateData = createData;
        }
        public Counter(string name, int serviceId, int serialNumber, int capacity, int decimalCapacity, float initialValue, DateTime createData)
            : this(0, name, serviceId, serialNumber, capacity, decimalCapacity, initialValue, createData)
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
                Counter p = (Counter)obj;
                return (Id == p.Id);
            }
        }
    }
}
