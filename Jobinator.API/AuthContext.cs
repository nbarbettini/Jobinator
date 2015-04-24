using System;
using AspNet.Identity.MongoDB;
using MongoDB.Driver;
using Jobinator.API.Models;

namespace Jobinator.API
{
	public class AuthContext : UserStore<IdentityUser>, IDisposable
	{
		public AuthContext(IMongoCollection<IdentityUser> users,
            IMongoCollection<Client> clients, IMongoCollection<RefreshToken> refreshTokens) 
            : base(users)
		{
            Clients = clients;
            RefreshTokens = refreshTokens;
		}

        public IMongoCollection<Client> Clients { get; private set; }
        public IMongoCollection<RefreshToken> RefreshTokens { get; private set; }

		public void Dispose()
		{
		}


        public static AuthContext Create()
        {
            // todo add settings where appropriate to switch server & database in your own application
            var client = new MongoClient("mongodb://192.168.2.140/?safe=true");
            var database = client.GetDatabase("NateTesting");
            var users = database.GetCollection<IdentityUser>("users");
            var clients = database.GetCollection<Client>("clients");
            var refreshTokens = database.GetCollection<RefreshToken>("tokens");
            return new AuthContext(users, clients, refreshTokens);
        }
    }
}