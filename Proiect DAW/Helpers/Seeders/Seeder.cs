using Proiect_DAW.Data;
using Proiect_DAW.Models;
namespace Proiect_DAW.Helpers.Seeders
{
    public class Seeder
    {
        public readonly AppDbContext _appDbContext;

        public Seeder(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void SeedVanzatori()
        {
            var Vanzator1 = new Vanzator
            {
                Nume = "Verik vanzare accesorii",
                Telefon = "40 702 024 961" //e generat random
            };

            _appDbContext.Vanzatori.Add(Vanzator1);
        }
    }
}
