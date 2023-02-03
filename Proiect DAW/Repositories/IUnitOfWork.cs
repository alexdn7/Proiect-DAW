using Proiect_DAW.Repositories.ProducatorRepository;
using Proiect_DAW.Repositories.ProdusRepository;
using Proiect_DAW.Repositories.VanzatorRepository;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories
{
    public interface IUnitOfWork
    {
        IProdusRepository ProdusRepository { get; }
        IVanzatorRepository VanzatorRepository { get; }
        IProducatorRepository ProducatorRepository { get; }

        Task<bool> SaveAsync();
    }
}
