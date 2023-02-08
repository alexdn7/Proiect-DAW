using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);

        Task<TEntity> FindByIdAsync(object id);

        void Update(TEntity entity);
        
        TEntity FindById(object id);
        
        Task<List<TEntity>> GetAllAsync();

        Task Delete(TEntity entity);

    }
}
