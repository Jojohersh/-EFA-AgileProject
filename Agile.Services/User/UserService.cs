using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Data;
using Agile.Data.Entities;
using Agile.Models.User;
using Microsoft.EntityFrameworkCore;

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
            Returns a populated UserDetail model if the provided userId is valid
            Returns a null object if the given userId is not a valid user
        */
        public async Task<UserDetail> GetUserByIdAsync(int userId) {
            var user = await _dbContext.Users.FindAsync(userId);
            
            return (user is null) 
                ? null
                : new UserDetail {
                    Id = user.Id,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                    BoxId = user.InboxId,
                    TotalMail = user.inbox.Mail.Count
                };
        }
        /*
            returns a UserDetail of the user using the provided email address
            returns null if email is not used by a user
        */
        public async Task<UserDetail> GetUserByEmailAsync(string emailAddress) {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.EmailAddress == emailAddress);

            return (user is null)
                ? null
                : new UserDetail {
                    Id = user.Id,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                    TotalMail = user.inbox.Mail.Count,
                    BoxId = user.InboxId
                };
        }
        // Update
        /*
            returns true if a valid user has been found and a valid new name has been provided
            returns false if userId is not a valid user
            returns false if the request is missing a new name of length 2 or more or is missing a userId
            returns false if no changes are made
        */
        public async Task<bool> UpdateUserAsync(int userId, UserUpdate request) {
            var oldUser = await _dbContext.Users.FindAsync(userId);
            if (oldUser is null)
                return false;
            
            oldUser.UserName = request.UserName;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            
            return (numberOfChanges == 1);
        }
        /*
            returns true if a valid user is deleted
            returns false if userId provided is invalid
            returns false if the user is not removed from the DB (such as a db error)
        */
        // Delete
        public async Task<bool> DeleteUserAsync(int userId) {
            var user = await _dbContext.Users.FindAsync(userId);

            if (user is null)
                return false;
            
            _dbContext.Users.Remove(user);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return (numberOfChanges == 1);
        }
    }
}