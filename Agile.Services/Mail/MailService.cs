using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Agile.Data;
using Agile.Data.Entities;
using Agile.Models.Mail;
using Microsoft.EntityFrameworkCore;

namespace Agile.Services.Mail
{
        public class MailService : IMailService
    {
        private readonly ApplicationDbContext _context;
        private int _userId;
        private ApplicationDbContext DbContext;

        public MailService(ApplicationDbContext context)
        {
            DbContext = context;
        }

        
        public async Task<bool> CreateMailAsync(MailCreate request)
        {
            var mailEntity = new MailEntity
            {
            Subject = request.Subject,
            Body = request.Body,
            SenderId = request.SenderId,
            ReceiverId = request.ReceiverId,
            BoxId = request.BoxId,
            };

            DbContext.Add(mailEntity);

            var numberOfChanges = await DbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteMailAsync(int mailId)
        {
            var mailEntity = await DbContext.Mail.FindAsync(mailId);

            if (mailEntity?.BoxId != _userId)
            return false;

            DbContext.Mail.Remove(mailEntity);
            return await DbContext.SaveChangesAsync() == 1;
        }

        public async Task<MailDetail> GetMailByIdAsync(int mailId)
        {
            var mailEntity = await DbContext.Mail.FirstOrDefaultAsync(e =>
            e.Id == mailId && e.BoxId == _userId);

            return (mailEntity is null) ? null : new MailDetail
            {
                BoxId  = mailEntity.BoxId,
                Subject = mailEntity.Subject,
                Body = mailEntity.Body,
                SenderId = mailEntity.SenderId,
                ReceiverId = mailEntity.ReceiverId
            };
        }

        public async Task<bool> UpdateMailAsync(MailUpdate request)
        {
            var mailEntity = await DbContext.Mail.FindAsync(request.BoxId);

            if (mailEntity?.BoxId != _userId)
            return false;

            mailEntity.Subject = request.Subject;
            mailEntity.Body = request.Body;
            mailEntity.SenderId = request.SenderId;
            mailEntity.ReceiverId = request.ReceiverId;
            
            var numberOfChanges = await DbContext.SaveChangesAsync();
            return numberOfChanges == 1;       
        }
    }
}