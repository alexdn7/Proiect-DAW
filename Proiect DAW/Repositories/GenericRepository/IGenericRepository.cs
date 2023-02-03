using Proiect_DAW.Models.Base;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);

        Task<TEntity> FindByIdAsync(object id);

        void Update(TEntity entity);

        void Delete(TEntity entity);

    }
}
