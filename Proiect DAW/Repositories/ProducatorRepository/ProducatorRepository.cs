using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Models.DTOs;
using Proiect_DAW.Repositories.GenericRepository;
using Proiect_DAW.Repositories.ProducatorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories.ProducatorRepository
{
    public class ProducatorRepository: GenericRepository<Producator>, IProducatorRepository
    {
        public ProducatorRepository(AppDbContext context) : base(context) { }

        //Linq - include
        //Prin intermediul acestei metode, se returneaza informatii despre locatia Producatorului al carui ID este dar ca parametru
        public async Task<Producator> GetLocationForProducerAsync(Guid ProducatorID)
        {
            return await _table.Include(c => c.Locatie)
                                .FirstOrDefaultAsync(c => c.Id == ProducatorID);
        }

        //Linq - join
        //Returneaza numarul produselor vandute de un producator al carui ID este dat ca parametru
        public async Task<int> GetNumberOfProdusesMadeByProducerAsync(Guid producatorId)
        {
            return await _context.Produse
                              .Join(_context.Producatori,
                                    produs => produs.ProductorId,
                                    producator => producator.Id,
                                    (produs, producator) => new { Produs = produs, Producator = producator })
                              .CountAsync(result => result.Producator.Id == producatorId);
        }
    }
}
