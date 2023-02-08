using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proiect_DAW.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            var allItems = await _table.AsNoTracking().ToListAsync();
            return allItems;
        }

        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }
        public TEntity FindById(object id)
        {
            return  _table.Find(id);
        }

        public async Task Delete(TEntity entity) 
        { 
            _table.Remove(entity);
        }
    }
}
