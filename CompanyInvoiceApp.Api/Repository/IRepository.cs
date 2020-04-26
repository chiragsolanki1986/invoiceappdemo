
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompanyInvoiceApp.Api.Repository
{

    public interface IRepository<T> where T : IEntity    
    {
        Task<List<T>> GetAllEntities();

        Task<List<T>> GetAllEntitiesForId(string id);

        Task<T> GetById(Guid id);

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);        
    }
    
}