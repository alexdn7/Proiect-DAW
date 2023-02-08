using Proiect_DAW.Data;
using Proiect_DAW.Repositories.ProducatorRepository;
using Proiect_DAW.Repositories.ProdusRepository;
using Proiect_DAW.Repositories.VanzatorRepository;
using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Proiect_DAW.Repositories.UsersRepository;
using Proiect_DAW.Repositories.LocatieRepository;

namespace Proiect_DAW.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        public IVanzatorRepository VanzatorRepository { get; set; }
        public IProdusRepository ProdusRepository { get; set; }
        public IProducatorRepository ProducatorRepository { get; set; }
        public IUserRepository UserRepository { get; set; }
        public ILocatieRepository LocatieRepository { get; }

        public AppDbContext _dbcontext { get; set; }

        public UnitOfWork(IVanzatorRepository vanzatorRepository, IProdusRepository produsRepository, IProducatorRepository producatorRepository, ILocatieRepository locatieRepository,IUserRepository userRepository, AppDbContext appDbContext) 
        {
            VanzatorRepository= vanzatorRepository;
            ProdusRepository = produsRepository;
            ProducatorRepository = producatorRepository;
            UserRepository = userRepository;
            LocatieRepository = locatieRepository; 
            _dbcontext = appDbContext;
        }
        
        public async Task<bool> SaveAsync()
        {
            try 
            {
                return await _dbcontext.SaveChangesAsync() > 0;
            }
            
            catch (SqlException eroare)
            {
                Console.WriteLine("Probleme la mansarda");
                Console.WriteLine(eroare);
            }

            return false;
        }

    }
}
