using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Data;

namespace Agile.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Create
        public async Task<bool> CreateUserAsync() {

        }
        // Read
        public async Task<UserEntity> GetUserAsync(int userId) {

        }
        // Update
        Task<bool> UpdateUserAsync(int userId/*, make an update model*/) {

        }
        // Delete
        Task<bool> DeleteUserAsync(int userId) {
            
        }
    }
}