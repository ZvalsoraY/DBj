using System.ComponentModel.DataAnnotations;
using Entities;

namespace WebJkx.Models
{
    public class ReadingViewModel
    {
        //private int _id;
        //private int _serviceId;
        //private double _curValue;
        //private DateTime _transDate;

        public int Id { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public double CurValue { get; set; }

        [Required]
        public DateTime TransDate { get; set; }

        public ReadingViewModel()
        {

        }

        public ReadingViewModel(Reading reading)
        {
            Id = reading.Id;
            ServiceId = reading.ServiceId;
            CurValue = reading.CurValue;
            TransDate = reading.TransDate;
        }
    }
}
