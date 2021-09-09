﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_GameStoreIL.Models
{
    public enum UserType
    {
        Client,
        Admin
    }
    public class User
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-zA-Z ]*$",ErrorMessage = "Username must contains only letters and start with one uppercase letter")]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{6,}$", ErrorMessage = "Use 6 or more characters with a mix of letters, numbers & symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        public int PhoneNumber { get; set; }

        public UserType Type { get; set; } = UserType.Client;

        // one <-> one : Cart <-> User
        public Cart Cart { get; set; } = new Cart();
    }
}
