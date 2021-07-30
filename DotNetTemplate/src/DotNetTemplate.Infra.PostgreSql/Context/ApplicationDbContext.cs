using DotNetTemplate.Domain.Model.Entities;
using DotNetTemplate.Domain.Model.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetTemplate.Infra.PostgreSql.Context {

    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<TeamEntity> Teams { get; set; }

        /// <summary>
        /// Usado para setar automaticamente as datas de Criação/Atualização de entidades no banco de dados.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken) {


            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach(var entityEntry in entries) {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;

                if(entityEntry.State == EntityState.Added) {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
