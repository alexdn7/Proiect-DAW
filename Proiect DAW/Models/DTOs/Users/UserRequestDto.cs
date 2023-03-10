using System.ComponentModel.DataAnnotations;

namespace Proiect_DAW.Models.DTOs.Users
{
    public class UserRequestDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
