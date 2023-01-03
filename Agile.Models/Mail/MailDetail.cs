using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Models.Mail
{
    public class MailDetail
    {
        public int Id {get; set;}
        public string Subject {get; set;}
        public string Body {get; set;}
        public int SenderId {get; set;}
        public int ReceiverId {get; set;}
        public int BoxId {get; set;} 
    }
}