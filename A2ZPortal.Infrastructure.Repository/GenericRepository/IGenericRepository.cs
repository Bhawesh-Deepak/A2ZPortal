using A2ZPortal.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace A2ZPortal.Infrastructure.Repository.GenericRepository
{
    public interface IGenericRepository<TEntity,T> where TEntity:class
    {
        Task<ResponseModel<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<ResponseModel<TEntity>> GetList(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<ResponseModel<TEntity>> GetSingle(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] navigationProperties);
        Task<ResponseModel<TEntity>> Add(params TEntity[] items);
        Task<ResponseModel<TEntity>> Update(params TEntity[] items);
        Task<ResponseModel<TEntity>> Delete(params TEntity[] items);
        Task<ResponseModel<TEntity>> CreateEntity(TEntity model);
    }
}