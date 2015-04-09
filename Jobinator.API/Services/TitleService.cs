using Jobinator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Jobinator.API.Services
{
    public class TitleService : MongoService<JobTitle> //: ITitleService
    {
        public TitleService(IMongoProvider mongo, string collection)
            : base(mongo, collection) { }

        public async Task<JobTitle> GetNext()
        {
            var randomGenerator = new Random();
            var random = randomGenerator.NextDouble();

            throw new NotImplementedException();
            //var builder = Builders<JobTitle>.Filter;
            //var lessThanRandomQuery = builder.Lte(x => x.RandomSeed, random);

            //var result = await _collection
            //    .Find(lessThanRandomQuery)
            //    .SortByDescending(x => x.RandomSeed)
            //    .FirstOrDefaultAsync();

            //return result;
        }
    }
}
