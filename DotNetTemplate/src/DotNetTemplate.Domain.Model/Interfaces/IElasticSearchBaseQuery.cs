using System.Threading.Tasks;

namespace DotNetTemplate.Domain.Model.Interfaces {

    public interface IElasticSearchBaseQuery<TModel, TIndexModel> where TIndexModel : class {
        Task<bool> IndexAsync(TModel document);
    }

    public interface IElasticSearchBaseQuery<TModel> : IElasticSearchBaseQuery<TModel, TModel> where TModel : class { }

}
