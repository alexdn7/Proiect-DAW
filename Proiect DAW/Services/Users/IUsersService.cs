using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.Users
{
    public interface IUsersService
    {
        UserResponseDto Atuhentificate(UserRequestDto model);
        Task<List<User>> GetAllUsers();
        User GetById(Guid id);
        Task Create(User newUser);
    }
}
