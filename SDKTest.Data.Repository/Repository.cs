using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDKTest.Data.DataAccess;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SDKTest.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext context { get; set; }
        internal DbSet<TEntity> dbSet;
        /*public Repository()
        {
            dbSet = context.Set<TEntity>();
        }*/

        public Repository(DbContext dbContext)
        {
            context = dbContext;
            dbSet = context.Set<TEntity>();
        }


        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public void CreateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Create(entity);
            }
        }

        public void Attach(TEntity entity)
        {
            dbSet.Attach(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
                
            }

            /*if (includes != null)
            {
                List<string> includeList = new List<string>();
                if (includes.Any())
                {
                    query = includes
                        .Where(x => !string.IsNullOrEmpty(x) && !includeList.Contains(x))
                        .Aggregate(query, (current, include) => current.Include(include));
                }
                else
                {
                    /*IEnumerable<INavigation> navigationProperties = context.Model.FindEntityType(typeof(TEntity)).GetNavigations();
                    if (navigationProperties == null)
                        return query;

                    foreach (INavigation navigationProperty in navigationProperties)
                    {
                        if (includeList.Contains(navigationProperty.Name))
                            continue;

                        includeList.Add(navigationProperty.Name);
                        query = query.Include(navigationProperty.Name);
                    }
                }

            }*/

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
