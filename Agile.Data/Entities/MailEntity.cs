using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Data.Entities
{
    public class MailEntity
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string Subject {get; set;}
        [Required]
        public string Body {get; set;}

        [Required]
        [ForeignKey(nameof(Sender))]
        public int SenderId {get; set;}
        public UserEntity Sender {get; set;}

        [Required]
        [ForeignKey(nameof(Receiver))]
        public int ReceiverId {get; set;}
        public UserEntity Receiver {get; set;}

        [Required]
        [ForeignKey(nameof(Inbox))]
        public int BoxId {get; set;} 
        public BoxEntity Inbox {get; set;}

    }
}