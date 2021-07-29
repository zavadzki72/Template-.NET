using AutoMapper;
using DotNetTemplate.Domain.Model.Entities.Base;
using DotNetTemplate.Domain.Model.Interfaces;
using DotNetTemplate.Infra.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetTemplate.Infra.PostgreSql.Repositories.Base {

    public class BaseRepository<TEntity, TDomain> : IBaseRepository<TEntity, TDomain>
            where TEntity : BaseEntity, new()
            where TDomain : class {

        protected readonly ApplicationDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        private readonly IMapper _mapper;

        public BaseRepository(IMapper mapper, ApplicationDbContext db) {
            DbContext = db;
            DbSet = db.Set<TEntity>();

            _mapper = mapper;
        }

        public virtual async Task<List<TDomain>> GetAll() {
            var result = await DbSet.ToListAsync();

            if(result == null)
                return null;

            var resultMap = _mapper.Map<List<TDomain>>(result);
            return resultMap;
        }

        public virtual async Task<TDomain> GetById(Guid id) {
            var result = await DbSet.FindAsync(id);

            if(result == null)
                return null;

            var resultMap = _mapper.Map<TDomain>(result);
            return resultMap;
        }

        public void Insert(TDomain item) {
            var map = _mapper.Map<TEntity>(item);
            DbSet.Add(map);
        }

        public async Task Update(TDomain item) {

            var map = _mapper.Map<TEntity>(item);
            var itemDb = await DbSet.FindAsync(map.Id);

            DbContext.Entry(itemDb).State = EntityState.Detached;
            var entry = DbContext.Entry(map);

            if(entry.State == EntityState.Detached)
                DbContext.Attach(map);

            DbContext.Entry(map).State = EntityState.Modified;
        }

        public void Delete(Guid id) {
            DbSet.Remove(new TEntity { Id = id });
        }

        public async Task<bool> Commit() {
            var success = await DbContext.SaveChangesAsync() > 0;
            return success;
        }

        public void Dispose() {
            DbContext?.Dispose();
        }

    }
}
