﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Models
{
    public class AdminRegistration
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int phone { get; set; }
        public string address { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Compare("password")]
        public string ConfirmPassword { get; set; }
    }
}
