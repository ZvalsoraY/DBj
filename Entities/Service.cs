using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Service
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

        public Service()
        {
            
        }
        public Service(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Service(string name)
            : this(0, name)
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
