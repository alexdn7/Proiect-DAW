using Proiect_DAW.Helpers.JwtUtils;
using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs.Users;
using Proiect_DAW.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.Users
{
    public class UsersService: IUsersService
    {
        public IUnitOfWork _IUnitOfWork;
        private IJwtUtils _jwtUtils;

        public UsersService(IUnitOfWork iUnitOfWork, IJwtUtils jwtUtils)
        {
            _IUnitOfWork = iUnitOfWork;
            _jwtUtils = jwtUtils;
        }

        public UserResponseDto Atuhentificate(UserRequestDto model)
        {
            var user = _IUnitOfWork.UserRepository.FindByUsername(model.UserName);
            if(user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null; 
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDto(user, jwtToken);
        }

        public async Task Create(User newUser)
        {
            await _IUnitOfWork.UserRepository.CreateAsync(newUser);
            await _IUnitOfWork.SaveAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _IUnitOfWork.UserRepository.GetAllAsync();
        }

        public User GetById(Guid id)
        {
            return _IUnitOfWork.UserRepository.FindById(id);
        }
    }
}
