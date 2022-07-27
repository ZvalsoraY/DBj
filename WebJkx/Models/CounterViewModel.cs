using System.ComponentModel.DataAnnotations;
using Entities;

namespace WebJkx.Models
{
    public class CounterViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int SerialNumber { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int DecimalCapacity { get; set; }

        [Required]
        public double InitialValue { get; set; }

        [Required]
        public DateTime CreateData { get; set; }

        public CounterViewModel()
        {

        }

        public CounterViewModel(Counter counter)
        {
            Id = counter.Id;
            Name = counter.Name;
            ServiceId = counter.ServiceId;
            SerialNumber = counter.SerialNumber;
            Capacity = counter.Capacity;
            DecimalCapacity = counter.DecimalCapacity;
            InitialValue = counter.InitialValue;
            CreateData = counter.CreateData;
        }
    }
}
