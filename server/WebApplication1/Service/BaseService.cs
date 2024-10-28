using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;
using WebApplication1.Persistent;

namespace WebApplication1.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Guid id);

        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> UpdateOnlyChangedProperties(Guid id, TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity);

        Task<List<TEntity>> GetByPagination(int skip, int limit, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
    }
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext Context;
        protected readonly DbSet<TEntity> DbSet;
        const int LIMIT = 50;
        protected BaseService(ApplicationContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            var result = await DbSet.FindAsync(id);
            if (result == null) throw new Exception($"Resouce of type {typeof(TEntity)} is not founded");
            return result;
        }


        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntity = (await DbSet.AddAsync(entity)).Entity;
            await Context.SaveChangesAsync();

            return addedEntity;
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
            var count = await Context.SaveChangesAsync();
            return count;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var removedEntity = DbSet.Remove(entity).Entity;
            await Context.SaveChangesAsync();

            return removedEntity;
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            var queryable = DbSet.AsQueryable();
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            orderBy?.Invoke(queryable);

            return await queryable.ToListAsync();
        }

        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await DbSet.Where(predicate).FirstOrDefaultAsync();

            if (entity == null) throw new Exception($"Resouce of type {typeof(TEntity)} is not folder");

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TEntity>> GetByPagination(int skip, int limit, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
        {
            var queryable = DbSet.AsQueryable();
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            if (orderBy != null)
            {
                queryable = orderBy?.Invoke(queryable);
            }
            if (queryable != null)
            {
                queryable = queryable.Skip(skip).Take(limit);
            }

            return await queryable.ToListAsync();
        }

        //public async Task<List<TEntity>> GetAllAsync(IFilter<TEntity> filer, Order order, Pagination pagination)
        //{
        //    var queryable = DbSet.AsQueryable();
        //    if (filer != null)
        //    {
        //        queryable = filer.filters(queryable);
        //    }
        //    if (order != null)
        //    {
        //        queryable = Order.ApplyOrdering(queryable, order.By, order.IsDesc);
        //    }
        //    if (pagination != null)
        //    {
        //        int skip = pagination.PageSize * (pagination.Page - 1);
        //        int take = pagination.PageSize;
        //        queryable = queryable.Skip(skip).Take(take);
        //    }
        //    return await queryable.ToListAsync();
        //}

        public async Task<TEntity> UpdateOnlyChangedProperties(Guid id, TEntity newEntity)
        {
            var currentEntity = await GetAsync(id);
            if (currentEntity == null)
            {
                throw new Exception("The id does not match any");
            }
            List<PropertyInfo> properties = [.. typeof(TEntity).GetProperties()];
            // Filter out the unchangeable properties
            properties = properties.Where(p =>
                    p.Name != "Id"
                    ).ToList();
            foreach (PropertyInfo property in properties)
            {
                var newValue = property.GetValue(newEntity);
                var currentValue = property.GetValue(newEntity);
                if (newValue != null && newValue != currentValue)
                {
                    property.SetValue(currentEntity, newValue);
                }
            }
            int result = await Context.SaveChangesAsync();
            return currentEntity;

        }

    //    public async Task<ListModel<TEntity>> GetAllAsListModelAsync(IFilter<TEntity> filer, Order order, Pagination pagination)
    //    {
    //        var queryable = DbSet.AsQueryable();
    //        if (filer != null)
    //        {
    //            queryable = filer.filters(queryable);
    //        }
    //        if (order != null)
    //        {
    //            queryable = Order.ApplyOrdering(queryable, order.By, order.IsDesc);
    //        }
    //        int total = queryable.Count();
    //        if (pagination != null)
    //        {
    //            int skip = pagination.PageSize * (pagination.Page - 1);
    //            int take = pagination.PageSize;
    //            queryable = queryable.Skip(skip).Take(take);
    //        }
    //        List<TEntity> entityList = await queryable.ToListAsync();
    //        return new ListModel<TEntity>() { Data = entityList, Total = total };
    //    }
    //}
}
}
