﻿using Proiect_DAW.Repositories.ProducatorRepository;
using Proiect_DAW.Repositories.ProdusRepository;
using Proiect_DAW.Repositories.VanzatorRepository;
using Proiect_DAW.Repositories.UsersRepository;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public interface IUnitOfWork
    {
        IVanzatorRepository VanzatorRepository { get; }
        IProdusRepository ProdusRepository { get; }
        IProducatorRepository ProducatorRepository { get; }
        IUserRepository UserRepository { get; }
        Task<bool> SaveAsync();
    }
}