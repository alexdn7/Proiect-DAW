﻿using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.GenericRepository;
using System.Linq;

namespace Proiect_DAW.Repositories.UsersRepository
{
    public class UsersRepository: GenericRepository<User>, IUserRepository
    {
        public UsersRepository(AppDbContext context): base(context)
        {

        }

        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.Username == username);
        }
    }
}
