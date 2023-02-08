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
    public class UserService: IUserService
    {
        public IUnitOfWork _IUnitOfWork;
        private IJwtUtils _jwtUtils;

        public UserService(IUnitOfWork iUnitOfWork, IJwtUtils jwtUtils)
        {
            _IUnitOfWork = iUnitOfWork;
            _jwtUtils = jwtUtils;
        }

        public async Task Create(User newUser)
        {
            await _IUnitOfWork.UserRepository.CreateAsync(newUser);
            await _IUnitOfWork.SaveAsync();
        }

        public UserResponseDto Authentificate(User model)
        {
            var user = _IUnitOfWork.UserRepository.FindByUsername(model.Name);
            if(user == null || !BCryptNet.Verify(model.PasswordHash, user.PasswordHash))
            {
                return null; 
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDto(user, jwtToken);
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
