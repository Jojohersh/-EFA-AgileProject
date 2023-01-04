using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Data;
using Agile.Data.Entities;
using Agile.Models.User;
using Agile.Services.Box;
using Microsoft.EntityFrameworkCore;

namespace Agile.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IBoxService _boxService;

        public UserService(ApplicationDbContext dbContext, IBoxService boxService)
        {
            _dbContext = dbContext;
            _boxService = boxService;
        }




        // Create
        /*
            Returns true if a valid email address and user's name are provided
            returns false if either are missing or if email is not a valid email format
            returns false if the provided model is invalid
        */
        public async Task<bool> RegisterUserAsync(UserRegister request) {
            if (request?.EmailAddress is null || request.UserName is null)
                return false;
            
            var user = await GetUserByEmailAsync(request.EmailAddress);

            if (user is not null)
                return false;
            
            var newUser = new UserEntity {
                UserName = request.UserName,
                EmailAddress = request.EmailAddress,
                // should I call the other service in h ere?
               // InboxId = 0
            };

            _dbContext.Users.Add(newUser);

            var numberOfChanges = await _dbContext.SaveChangesAsync();
            
            //fetch user and get their Id
            //create a new BoxEntity using the user's Id
            
          
            //add to db
            //save changes

            return (numberOfChanges == 1);
        }
        // Read
        /*
            Returns a populated UserDetail model if the provided userId is valid
            Returns a null object if the given userId is not a valid user
        */
        public async Task<UserDetail> GetUserByIdAsync(int userId) {
                  var user = await _dbContext.Users.Include(u=>u.MailBoxes).FirstOrDefaultAsync(user => user.Id==userId);

            return (user is null)
                ? null
                : new UserDetail {
                    Id = user.Id,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                  //  TotalMail = user.inbox.Mail.Count,
                   // BoxId = user.InboxId,
                    MailBoxes=user.MailBoxes.Select(m=>new BoxEntityListItem{
                            Id = m.Id,
                            BoxName=m.BoxName
                    }).ToList()
                };
        }
        /*
            returns a UserDetail of the user using the provided email address
            returns null if email is not used by a user
        */
        public async Task<UserDetail> GetUserByEmailAsync(string emailAddress) {
            
            var user = await _dbContext.Users.Include(u=>u.MailBoxes).FirstOrDefaultAsync(user => user.EmailAddress.ToLower() == emailAddress.ToLower());

            return (user is null)
                ? null
                : new UserDetail {
                    Id = user.Id,
                    UserName = user.UserName,
                    EmailAddress = user.EmailAddress,
                  //  TotalMail = user.inbox.Mail.Count,
                   // BoxId = user.InboxId,
                    MailBoxes=user.MailBoxes.Select(m=>new BoxEntityListItem{
                            Id = m.Id,
                            BoxName=m.BoxName
                    }).ToList()
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