using System.Threading;
using System.Threading.Tasks;
using IdentityServer.Management.Users.Abstractions;
using IdentityServer.Seeders;
using Microsoft.AspNetCore.Identity;

namespace IdentityServer.Management.Users
{
    public class UserService<T> : IUserService<T>, ISeedService<T>
        where T : IdentityUser
    {
        private readonly IUserStore<T> _userStore;

        public UserService(IUserStore<T> userStore)
        {
            _userStore = userStore;
        }

        public async Task Create(T user, CancellationToken cancellationToken = default)
        {
            var foundUser = await _userStore.FindByNameAsync(user.UserName, cancellationToken);
            if (foundUser != null) return;
            await _userStore.CreateAsync(user, cancellationToken);
        }

        public async Task Update(T user, CancellationToken cancellationToken = default)
        {
            var foundUser = await _userStore.FindByIdAsync(user.Id, cancellationToken);
            if (foundUser == null) return;

            await _userStore.UpdateAsync(user, cancellationToken);
        }

        public async Task<T> GetByUsername(string username, CancellationToken cancellationToken = default)
        {
            var user = await _userStore.FindByNameAsync(username, cancellationToken);
            return user;
        }
    }
}