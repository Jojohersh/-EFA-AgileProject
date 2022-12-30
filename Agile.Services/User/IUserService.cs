using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Services.User
{
    public interface IUserService
    {
        // Create
        Task<bool> CreateUserAsync();
        // Read
        Task<UserEntity> GetUserAsync(int userId);
        // Update
        Task<bool> UpdateUserAsync(int userId/*, make an update model*/);
        // Delete
        Task<bool> DeleteUserAsync(int userId);
    }
}