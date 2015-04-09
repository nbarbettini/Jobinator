using System;
using AspNet.Identity.MongoDB;
using MongoDB.Driver;

namespace Jobinator.API
{
	public class AuthContext : UserStore<IdentityUser>, IDisposable
	{
		public AuthContext(IMongoCollection<IdentityUser> users) : base(users)
		{
		}

		public static AuthContext Create()
		{
			// todo add settings where appropriate to switch server & database in your own application
			var client = new MongoClient("mongodb://localhost");
			var database = client.GetDatabase("NateTesting");
			var users = database.GetCollection<IdentityUser>("users");
            return new AuthContext(users);
		}

		public void Dispose()
		{
		}
    }
}