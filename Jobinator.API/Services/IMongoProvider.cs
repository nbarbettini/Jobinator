using System;
namespace Jobinator.API.Services
{
    public interface IMongoProvider
    {
        MongoDB.Driver.IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
