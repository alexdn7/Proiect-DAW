using System;

namespace Proiect_DAW.Models.DTOs.Users
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Token { get; set; }

        public UserResponseDto(User user , string token)
        {
            Id = user.Id;
            Name = user.Name;
            Nickname = user.Nickname;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Token = token;
        }
    }
}
