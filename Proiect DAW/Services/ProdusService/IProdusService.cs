using Proiect_DAW.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.ProdusService
{
    public interface IProdusService
    {
        Task Create(Produs produs);
        Task<List<Produs>> GetAll();
    }
}
