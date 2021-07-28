using DotNetTemplate.Domain.Model.Entities;
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
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
            
            foreach(var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null)) {

                if(entry.State == EntityState.Added) {
                    var date = DateTime.Now;

                    entry.Property("create_date").CurrentValue = date;
                    entry.Property("update_date").CurrentValue = date;
                }

                if(entry.State == EntityState.Modified)
                    entry.Property("update_date").CurrentValue = DateTime.Now;
            
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
