using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Jobinator.API.Models;

namespace Jobinator.API.Services
{
    public class MongoService<T>
        where T : IMongoId
    {
        protected readonly IMongoCollection<T> _collection;

        public MongoService(IMongoProvider mongo, string collection)
        {
            _collection = mongo.GetCollection<T>(collection);
        }
    }
}
