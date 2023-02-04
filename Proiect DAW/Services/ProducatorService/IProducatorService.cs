using Proiect_DAW.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.ProducatorService
{
    public interface IProducatorService
    {
        Task AddProducator(Producator newProducator);
        Task<List<Producator>> GetAll();

        Task DeleteProducator(Guid ProducatorId);
    }
}
