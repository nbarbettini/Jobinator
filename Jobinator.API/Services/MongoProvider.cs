using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobinator.API.Services
{
    public class MongoProvider : Jobinator.API.Services.IMongoProvider
    {
        private readonly IMongoDatabase _db;

        public MongoProvider(string connection, string database)
        {
            var client = new MongoClient(connection);
            _db = client.GetDatabase(database);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return _db.GetCollection<T>(collectionName);
        }
    }
}