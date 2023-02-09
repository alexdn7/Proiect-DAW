using Proiect_DAW.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Services.ProducatorService
{
    public interface IProducatorService
    {
        Task Create(Producator newProducator);
        Task<List<Producator>> GetAll();
        Task<Producator> GetLocationForProducerAsync(Guid ProducatorID);
        Task<int> GetNumberOfProdusesMadeByProducerAsync(Guid producatorId);
    }
}
