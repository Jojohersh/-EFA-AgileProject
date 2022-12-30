using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Services.User
{
    public class UserService : IUserService
    {
        // Create
        public async Task<bool> CreateUserAsync() {

        };
        // Read
        public async Task<UserEntity> GetUserAsync(int userId) {

        };
        // Update
        Task<bool> UpdateUserAsync(int userId/*, make an update model*/) {

        };
        // Delete
        Task<bool> DeleteUserAsync(int userId) {
            
        };
    }
}