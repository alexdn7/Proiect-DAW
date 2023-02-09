using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories.ProducatorRepository
{
    public interface IProducatorRepository: IGenericRepository<Producator>
    {
        Task<Producator> GetLocationForProducerAsync(Guid ProducatorID);
        Task<int> GetNumberOfProdusesMadeByProducerAsync(Guid producatorId);
    }
}
