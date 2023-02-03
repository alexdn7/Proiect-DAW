using Proiect_DAW.Data;
using Proiect_DAW.Repositories.ProducatorRepository;
using Proiect_DAW.Repositories.ProdusRepository;
using Proiect_DAW.Repositories.VanzatorRepository;
using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using Proiect_DAW.Repositories.UsersRepository;

namespace Proiect_DAW.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        public IProdusRepository ProdusRepository { get; set; }
        public IVanzatorRepository VanzatorRepository { get; set; }
        public IProducatorRepository ProducatorRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public AppDbContext _dbcontext { get; set; }

        public UnitOfWork(IProdusRepository produsRepository, IVanzatorRepository vanzatorRepository,IProducatorRepository producatorRepository, IUserRepository userRepository, AppDbContext appDbContext) 
        {
            ProdusRepository = produsRepository;
            VanzatorRepository= vanzatorRepository;
            ProducatorRepository = producatorRepository;
            UserRepository = userRepository;
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
