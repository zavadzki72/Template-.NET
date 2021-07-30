using AutoMapper;
using DotNetTemplate.Domain.Model.Interfaces;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Threading.Tasks;

namespace DotNetTemplate.Infra.ElasticSearch {

    public abstract class BaseQuery<TModel, TIndexModel> : IElasticSearchBaseQuery<TModel, TIndexModel> where TModel : class where TIndexModel : class {

        private ElasticClient _client = null;

        protected readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        internal ElasticClient Client {
            get {
                if(_client == null) {
                    _client = GetClient();
                }

                return _client;
            }
        }

        private static string DefaultIndex {
            get {
                IElasticSearchQueryModel instance = (IElasticSearchQueryModel)Activator.CreateInstance(typeof(TIndexModel), true);
                return instance.GetIndexName;
            }
        }

        public BaseQuery(IMapper mapper, IConfiguration configuration) {
            _mapper = mapper;
            _configuration = configuration;
        }

        internal ElasticClient GetClient() {

            if(_client != null)
                return _client;

            var url = _configuration["Elasticsearch:Url"];
            var uris = new[] { new Uri(url) };

            var connectionPool = new SniffingConnectionPool(uris);
            var connection = new HttpConnection();
            var connectionSettings = new ConnectionSettings(connectionPool, connection).DefaultIndex(DefaultIndex);

#if DEBUG
            connectionSettings.EnableDebugMode().PrettyJson(); //Debugging
#endif

            connectionSettings.DisablePing();
            connectionSettings.SniffOnStartup(false);

            _client = new ElasticClient(connectionSettings);

            return _client;
        }


        public async Task<bool> IndexAsync(TModel document) {

            var indexModel = _mapper.Map<TIndexModel>(document);

            var indexName = indexModel.GetType().GetProperty("GetIndexName").GetValue(indexModel, null);

            var request = new IndexRequest<TIndexModel>(index: indexName.ToString()) {
                Document = indexModel
            };

            await Client.IndexAsync(request);

            return true;
        }

        public async Task<bool> RemoveAllAsync() {
            await Client.DeleteByQueryAsync<TIndexModel>(d => d.MatchAll());
            return true;
        }
    }

    internal class LazyAsync<T> : Lazy<Task<T>> {
        public LazyAsync(Func<Task<T>> taskFactory) : base(
            () => Task.Factory.StartNew(taskFactory).Unwrap()) { }
    }
}
