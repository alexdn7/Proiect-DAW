using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.VanzatorService
{
    public interface IVanzatorService
    {
        Task Create(Vanzator newVanzator);
        Task<List<Vanzator>> GetAll();
        Task<bool> Update(Guid VanzatorID, VanzatorDto vanzator);
        Task Delete(Guid VanzatorID);
    }
}
