using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.GenericRepository;
using Proiect_DAW.Repositories.ProducatorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories.VanzatorRepository
{
    public class VanzatorRepository: GenericRepository<Vanzator>, IVanzatorRepository
    {
        public VanzatorRepository(AppDbContext context) : base(context) { }
    }
}
