using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Data;
using Agile.Data.Entities;
using Agile.Models.User;

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
        public async Task<bool> CreateUserAsync(UserRegister model) {
            if (model?.EmailAddress is null || model.UserName is null)
                return false;
            
            var newUser = new UserEntity {
                UserName = model.UserName,
                EmailAddress = model.EmailAddress,
                // should I call the other service in here?
                // InboxId = CreateBoxAsync()
            };

            _dbContext.Users.Add(newUser);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return (numberOfChanges == 1);
        }
        // Read
        /*
            Returns a populated UserEntity from the database if the provided userId is valid
            Returns a null object if the given userId is not a valid user
        */
        public async Task<UserDetail> GetUserByIdAsync(int userId) {
            var user = await _dbContext.Users.FindAsync(userId);
            
            return (user is null) ? null
                : new UserDetail {
                    Id = user.Id,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                    BoxId = user.InboxId,
                    TotalMail = user.inbox.Mail.Count
                };
        }
        // // Update
        // Task<bool> UpdateUserAsync(int userId/*, make an update model*/) {

        // }
        // // Delete
        // Task<bool> DeleteUserAsync(int userId) {
            
        // }
    }
}