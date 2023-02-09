using Proiect_DAW.Data;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories.ProdusRepository
{
    public class ProdusRepository: GenericRepository<Produs>, IProdusRepository
    {
        public ProdusRepository(AppDbContext context) : base(context) { }

        //Where - Returneaza toate produsele cu pretul mai mic decat cel dat ca parametru

        public List<Produs> GetAllProdusesWithPriceUnder(double pret)
        {
            return _context.Produse.Where(p => p.Pret < pret).ToList();
        }

        //Groupby - returneaza produsele grupate dupa producator
        public IEnumerable<IGrouping<Producator, Produs>> GroupByProducator()
        {
            return _context.Produse.GroupBy(p => p.Producator);
        }
    }
}
