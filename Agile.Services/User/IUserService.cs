using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Data.Entities;
using Agile.Models.User;

namespace Agile.Services.User
{
    public interface IUserService
    {
        // Create
        Task<bool> RegisterUserAsync(UserRegister model); //* changed to match naming conventions
        // Read
        Task<UserDetail> GetUserByIdAsync(int userId);
        
        // // Update
        Task<bool> UpdateUserAsync(int userId, UserUpdate request);
        // // Delete
        Task<bool> DeleteUserAsync(int userId);
    }
}