using System;
using System.Linq;

using IntiCms.Interfaces;
using IntiCms.ValueObjects;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace IntiCms.BusinessLogic
{
    public class MongoDbEntryAdapter : IEntryAdapter
    {
        private const string MongoDbIdFieldName = "_id";

        private readonly string _Databasename;

        private readonly MongoServer _Server;

        static MongoDbEntryAdapter()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof (Entry)))
            {
                BsonClassMap.RegisterClassMap<Entry>(
                    cm =>
                        {
                            cm.AutoMap();
                            cm.SetIdMember(cm.GetMemberMap(c => c.Slug));
                        });
            }
        }

        public MongoDbEntryAdapter(string connectionString, string databaseName)
        {
            CollectionName = "IntiCms";
            _Databasename = databaseName;
            _Server = MongoServer.Create(connectionString);
        }

        public string CollectionName { get; set; }

        public Entry One(string slug)
        {
            var collection = GetCollection();

            var entity = collection.FindOneByIdAs<Entry>(BsonValue.Create(EnsureKey(slug)));

            return entity;
        }

        public IQueryable<Entry> All()
        {
            var collection = GetCollection();
            var result = collection.AsQueryable<Entry>();
            return result;
        }

        public void Save(Entry entry)
        {
            if (entry == null)
            {
                throw new ArgumentNullException("entry");
            }

            entry.Slug = EnsureKey(entry.Slug);

            var collection = GetCollection();
            collection.Save(entry);
        }

        public void Delete(string slug)
        {
            var collection = GetCollection();

            var query = Query.EQ(MongoDbIdFieldName, BsonValue.Create(EnsureKey(slug)));

            collection.Remove(query, RemoveFlags.Single);
        }

        private static string EnsureKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException("key");
            }

            return key.ToLower();
        }

        private MongoCollection GetCollection()
        {
            return _Server.GetDatabase(_Databasename).GetCollection(CollectionName);
        }
    }
}