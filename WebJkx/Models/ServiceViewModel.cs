﻿using System.ComponentModel.DataAnnotations;
using Entities;

namespace WebJkx.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ServiceViewModel()
        {

        }

        public ServiceViewModel(Service service)
        {
            Id = service.Id;
            Name = service.Name;
        }
    }
}
