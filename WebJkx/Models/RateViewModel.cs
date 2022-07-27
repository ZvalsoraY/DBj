using System.ComponentModel.DataAnnotations;
using Entities;

namespace WebJkx.Models
{
    public class RateViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public DateTime StartData { get; set; }

        [Required]
        public DateTime EndData { get; set; }

        [Required]
        public int ServiceId { get; set; }

        public RateViewModel()
        {

        }

        public RateViewModel(Rate rate)
        {
            Id = rate.Id;
            Name = rate.Name;   
            Price = rate.Price;
            StartData = rate.StartData;
            EndData = rate.EndData;
            ServiceId = rate.ServiceId;
        }
    }
}
