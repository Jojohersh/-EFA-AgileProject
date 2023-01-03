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
        /*
            Returns true if a valid email address and user's name are provided
            returns false if either are missing or if email is not a valid email format
            returns false if the provided model is invalid
        */
        public async Task<bool> CreateUserAsync() {

        }
        // Read
        /*
            Returns a populated UserEntity from the database if the provided userId is valid
            Returns a null object if the given userId is not a valid user
        */
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