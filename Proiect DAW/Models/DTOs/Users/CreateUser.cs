using Microsoft.AspNetCore.Authorization.Infrastructure;
using Proiect_DAW.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models.DTOs.Users
{
    public class CreateUser
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public Role RoleName { get; set; }
    }
}
