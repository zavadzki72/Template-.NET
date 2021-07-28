using DotNetTemplate.Domain.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetTemplate.Domain.Model.Interfaces {

    public interface IBaseRepository<TEntity, TDomain> : IDisposable
            where TEntity : BaseEntity
            where TDomain : class {

        Task<List<TDomain>> GetAll();
        Task<TDomain> GetById(Guid id);
        void Insert(TDomain item);
        void Update(TDomain item);
        void Delete(Guid id);

        Task<bool> Commit();
    }
}
