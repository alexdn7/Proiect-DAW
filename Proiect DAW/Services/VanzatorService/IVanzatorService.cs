using Proiect_DAW.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.VanzatorService
{
    public interface IVanzatorService
    {
        Task Create(Vanzator newVanzator);
        Task<List<Vanzator>> GetAll();
    }
}
