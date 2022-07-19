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
        public Counter(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Counter(string name) : this(0, name)
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
                Counter p = (Counter)obj;
                return (Id == p.Id);
            }
        }
    }
}
