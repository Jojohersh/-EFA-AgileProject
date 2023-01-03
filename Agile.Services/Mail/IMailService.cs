using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Models.Mail;

namespace Agile.Services.Mail
{
    public interface IMailService
    {
        Task<bool> CreateMailAsync(MailCreate request);
        Task<MailDetail> GetMailByIdAsync(int mailId);
        Task<bool> UpdateMailAsync(MailUpdate request);
        Task<bool> DeleteMailAsync(int mailId);
    }
}