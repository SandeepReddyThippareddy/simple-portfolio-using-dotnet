﻿using System.ComponentModel.DataAnnotations;

namespace SandeepThippareddy.Dtos
{
    public class ContactDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name="Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
