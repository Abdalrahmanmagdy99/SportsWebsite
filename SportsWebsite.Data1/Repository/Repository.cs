using Microsoft.EntityFrameworkCore;
using SprotsWebsite.Domain.DbContexts;
using SprotsWebsite.Domain.Interfaces;

namespace SprotsWebsite.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _entities;

        public Repository(SprotsWebsiteDbContext context)
        {
            _entities = context.Set<TEntity>();
        }


        ///<inheritdoc/>
        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _entities.FindAsync(id);
        }
        ///<inheritdoc/>
        public IQueryable<TEntity> GetAsIQueryable()
        {
            return _entities.AsQueryable();
        }

        ///<inheritdoc/>
        public IQueryable<TEntity> GetWithNoTracking()
        {
            return _entities.AsNoTracking();
        }

        ///<inheritdoc/>
        public TEntity Insert(TEntity element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            _entities.Add(element);
            return element;

        }

        ///<inheritdoc/>
        public async Task<TEntity> InsertAsync(TEntity element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            await _entities.AddAsync(element);
            return element;

        }

        ///<inheritdoc/>
        public void InsertRange(IEnumerable<TEntity> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            _entities.AddRange(elements);

        }

        public async Task InsertRangeAsync(IEnumerable<TEntity> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            await _entities.AddRangeAsync(elements);

        }
        ///<inheritdoc/>
        public TEntity Update(TEntity element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            _entities.Update(element);
            return element;

        }

        public void UpdateRange(IEnumerable<TEntity> element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            _entities.UpdateRange(element);

        }

        ///<inheritdoc/>
        public bool Delete(TEntity element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }


            if (!typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
                return false;

            if (((ISoftDelete)element).IsDeleted == true)
            {
                return false;
            }

            ((ISoftDelete)element).IsDeleted = true;
            return true;
        }

        ///<inheritdoc/>
        public bool HardDelete(TEntity element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            _entities.Remove(element);
            return true;
        }
    }
}
