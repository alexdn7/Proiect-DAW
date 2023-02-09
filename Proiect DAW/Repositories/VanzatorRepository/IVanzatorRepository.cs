using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories.VanzatorRepository
{
    public interface IVanzatorRepository: IGenericRepository<Vanzator>
    {
    }
}
