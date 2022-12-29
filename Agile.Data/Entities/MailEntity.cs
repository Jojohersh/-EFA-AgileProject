using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Data.Entities
{
    public class MailEntity
    {
        [Key]
        public int Id {get; set;}
        public UserEntity From {get; set;}
        public UserEntity To {get; set;}
        public string Subject {get; set;}
        public string Body {get; set;}
        public int BoxId {get; set;} 
        public BoxEntity Inbox {get; set;}

    }
}