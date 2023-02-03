using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.GenericRepository;

namespace Proiect_DAW.Repositories.ProdusRepository
{
    public class ProdusRepository: GenericRepository<Produs>, IProdusRepository
    {
        public ProdusRepository(AppDbContext context) : base(context) { }
    }
}
