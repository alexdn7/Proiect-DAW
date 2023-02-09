using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Models;
using Proiect_DAW.Repositories.GenericRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories.ProdusRepository
{
    public interface IProdusRepository : IGenericRepository<Produs>
    {
        List<Produs> GetAllProdusesWithPriceUnder(double pret);
        IEnumerable<IGrouping<Producator, Produs>> GroupByProducator();
    }
}
