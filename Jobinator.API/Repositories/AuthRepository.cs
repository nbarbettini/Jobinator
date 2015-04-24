using AspNet.Identity.MongoDB;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jobinator.API.Models;
using MongoDB.Driver;

namespace Jobinator.API.Repositories
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = AuthContext.Create();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx.Users));
        }

        public async Task<IdentityResult> RegisterUser(Models.User userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<Client> FindClient(string clientId)
        {
            var client = await _ctx.Clients
                .Find(x => x.IdName == clientId)
                .SingleOrDefaultAsync();

            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = await _ctx.RefreshTokens
                .Find(r => r.Subject == token.Subject && r.ClientId == token.ClientId)
                .SingleOrDefaultAsync();

            if (existingToken != null)
            {
                var result = await RemoveRefreshToken(existingToken);
            }

            await _ctx.RefreshTokens.InsertOneAsync(token);

            return true;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens
                .Find(x => x.Id == refreshTokenId)
                .SingleOrDefaultAsync();

            if (refreshToken != null)
            {
                var result = await _ctx.RefreshTokens.DeleteOneAsync(x => x.Id == refreshToken.Id);
                return (result.IsAcknowledged && result.DeletedCount > 0);
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            return await RemoveRefreshToken(refreshToken.Id);
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await _ctx.RefreshTokens
                .Find(x => x.Id == refreshTokenId)
                .SingleOrDefaultAsync();

            return refreshToken;
        }

        public async Task<List<RefreshToken>> GetAllRefreshTokens()
        {
            return await _ctx.RefreshTokens
                .Find(_ => true)
                .ToListAsync();
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
