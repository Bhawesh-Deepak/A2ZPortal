using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using A2ZPortal.Core.Entities.Common;
using A2ZPortal.Core.Entities.Context;
using A2ZPortal.Infrastructure.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace A2ZPortal.Infrastructure.Implementation.GenericImplementation
{
    public class GenericImplementationDetail<TEntity, T> : IGenericRepository<TEntity, T> where TEntity : class
    {
        private readonly DbSet<TEntity> TEntities;
        public PortalContext baseContext;

        public GenericImplementationDetail(IConfiguration configutation)
        {
            baseContext = new PortalContext(configutation);
            TEntities = baseContext.Set<TEntity>();
        }

        public async Task<ResponseModel<TEntity>> Add(params TEntity[] items)
        {
            try
            {
                await baseContext.AddRangeAsync(items);
                await baseContext.SaveChangesAsync();

                return new ResponseModel<TEntity>(null, null, ResponseStatus.Created,
                    ResponseStatus.Created.ToString());
            }
            catch (Exception ex)
            {
                return new ResponseModel<TEntity>(null, null, ResponseStatus.Error,
                    ex.Message);
            }
        }

        public async Task<ResponseModel<TEntity>> CreateEntity(TEntity model)
        {
            try
            {
                await TEntities.AddAsync(model);
                await baseContext.SaveChangesAsync();
                return new ResponseModel<TEntity>(null, null, ResponseStatus.Created,
                    ResponseStatus.Created.ToString());
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("The duplicate key "))
                    return new ResponseModel<TEntity>(null, null, ResponseStatus.AlreadyExists,
                        ex.Message);
                return new ResponseModel<TEntity>(null, null, ResponseStatus.Error,
                    ex.Message);
            }
        }

        public async Task<ResponseModel<TEntity>> Delete(params TEntity[] items)
        {
            try
            {
                baseContext.UpdateRange(items);
                await baseContext.SaveChangesAsync();
                return new ResponseModel<TEntity>(null, null, ResponseStatus.Deleted,
                    ResponseStatus.Deleted.ToString());
            }
            catch (Exception ex)
            {
                return new ResponseModel<TEntity>(null, null, ResponseStatus.Error,
                    ex.Message);
            }
        }

        public Task<ResponseModel<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<TEntity>> GetList(Func<TEntity, bool> where,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            IQueryable<TEntity> dbQuery = baseContext.Set<TEntity>();
            foreach (var navigationProp in navigationProperties) dbQuery.Include(navigationProp);
            var response = await dbQuery.AsNoTracking().ToListAsync();
            return new ResponseModel<TEntity>(null, response, ResponseStatus.Success,
                ResponseStatus.Success.ToString());
        }

        public async Task<ResponseModel<TEntity>> GetSingle(Func<TEntity, bool> where,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            TEntity item = null;
            IQueryable<TEntity> dbQuery = baseContext.Set<TEntity>();
            foreach (var navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);

            item = dbQuery.AsNoTracking().FirstOrDefault(where);
            return await Task.Run(() => new ResponseModel<TEntity>(item, null, ResponseStatus.Success,
                ResponseStatus.Success.ToString()));
        }

        public async Task<ResponseModel<TEntity>> Update(params TEntity[] items)
        {
            try
            {
                baseContext.UpdateRange(items);
                await baseContext.SaveChangesAsync();
                return new ResponseModel<TEntity>(null, null, ResponseStatus.Updated,
                    ResponseStatus.Updated.ToString());
            }
            catch (Exception ex)
            {
                return new ResponseModel<TEntity>(null, null, ResponseStatus.Error,
                    ex.Message);
            }
        }
    }
}