using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.LocatieService
{
    public interface ILocatieService
    {
        Task Create(Locatie newLocatie);
        Task<List<Locatie>> GetAll();
        Task<bool> Update(Guid LocatieID, LocatieDto locatie);
        Task Delete(Guid LocatieID);
    }
}
