using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.GenericRepository;

namespace Proiect_DAW.Repositories.LocatieRepository
{
    public class LocatieRepository: GenericRepository<Locatie>, ILocatieRepository
    {
        public LocatieRepository(AppDbContext context) : base(context) { }
    }
}
