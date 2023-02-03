using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.GenericRepository;
using Proiect_DAW.Repositories.ProducatorRepository;

namespace Proiect_DAW.Repositories.ProducatorRepository
{
    public class ProducatorRepository: GenericRepository<Producator>, IProducatorRepository
    {
        public ProducatorRepository(AppDbContext context) : base(context) { }
    }
}
