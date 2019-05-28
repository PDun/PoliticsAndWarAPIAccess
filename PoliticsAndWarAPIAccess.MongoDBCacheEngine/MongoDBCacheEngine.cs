using MongoDB.Driver;
using PoliticsAndWarAPIAccess.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace PoliticsAndWarAPIAccess.MongoDBCacheEngine
{
    /// <summary>
    /// Class to use the MongoDB Caching Engine
    /// Free instance can be found https://cloud.mongodb.com/user#/atlas/login
    /// </summary>
    public class MongoDBCacheEngine<T> : ICacheEngine<T> where T : CacheModel
    {
        IMongoDatabase database;
        public MongoDBCacheEngine(string connectionString, string databaseName)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings =
            new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            var client = new MongoClient(settings);
            database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase GetDatabase()
        {
            return this.database;
        }

        public async Task<long> Build(T entity)
        {
            var collection = database.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Where(x => x._id == entity._id);
            var result = await collection.ReplaceOneAsync(
              filter: filter,
              options: new UpdateOptions { IsUpsert = true },
              replacement: entity);
            return result.ModifiedCount;
        }
        public async Task<bool> Build(IEnumerable<T> entities)
        {
            if (entities.Any())
            {
                var collection = database.GetCollection<T>(typeof(T).Name);

                var filterBuilder = Builders<T>.Filter;
                foreach (var models in this.Batch(entities, 1000))
                {
                    var updates = new List<WriteModel<T>>();
                    foreach (var model in models)
                    {
                        var filter = filterBuilder.Where(x => x._id == model._id);
                        updates.Add(new ReplaceOneModel<T>(filter, model) { IsUpsert = true });
                    }
                    await collection.BulkWriteAsync(updates);
                }
                return true;
            }
            return false;
        }
        public void DeleteFromCache(Expression<Func<T, bool>> expr)
        {
            var collection = database.GetCollection<T>(typeof(T).Name);
            collection.DeleteMany(expr);
        }
        public IEnumerable<T> Get(Expression<Func<T, bool>> expr)
        {
            var collection = database.GetCollection<T>(typeof(T).Name);
            return collection.Find(expr).ToList();
        }
        public IEnumerable<T> GetAll()
        {
            var collection = database.GetCollection<T>(typeof(T).Name);
            return collection.Find(_ => true).ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var collection = database.GetCollection<T>(typeof(T).Name);
            var result = await collection.FindAsync(x => x.CreatedDate > DateTime.Today.AddDays(-7));
            return result.ToList();
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expr)
        {
            var collection = database.GetCollection<T>(typeof(T).Name);
            var result = await collection.FindAsync(expr);
            return result.ToList();
        }
        public async Task<IEnumerable<T>> FindAsync(string collectionName, Expression<Func<T, bool>> expr)
        {
            var collection = database.GetCollection<T>(collectionName);
            var result = await collection.FindAsync(expr);
            return result.ToList();
        }
        public async Task<int> GetMaxId()
        {
            var collection = database.GetCollection<T>(typeof(T).Name);
            var result = await collection.Find(x => true).SortByDescending(d => d._id).Limit(1).FirstOrDefaultAsync();
            return result._id;
        }
        private IEnumerable<IEnumerable<T>> Batch(IEnumerable<T> collection, int batchSize)
        {
            List<T> nextbatch = new List<T>(batchSize);
            foreach (T item in collection)
            {
                nextbatch.Add(item);
                if (nextbatch.Count == batchSize)
                {
                    yield return nextbatch;
                    nextbatch = new List<T>();
                }
            }

            if (nextbatch.Count > 0)
                yield return nextbatch;
        }
    }
}
