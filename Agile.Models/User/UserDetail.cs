using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Models.User
{
    public class UserDetail
    {
        public int Id {get; set;}
        public string UserName {get; set;}
        public string EmailAddress {get; set;}
        
        // a count representing the user's total count of mail
        public int TotalMail {get; set;}
        // the id reference to the user's inbox (for potential navigation possibility)
        public int BoxId {get;set;}
        public List<BoxEntityListItem> MailBoxes { get; set; }
    }
}