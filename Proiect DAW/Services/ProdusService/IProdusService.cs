using Proiect_DAW.Models;
using System;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.ProdusService
{
    public interface IProdusService
    {
        Task AddProdus(Produs produs);
        Task DeleteProdus(Guid id);
    }
}
