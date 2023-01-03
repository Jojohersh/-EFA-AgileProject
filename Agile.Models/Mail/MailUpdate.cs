using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Models.Mail
{
    public class MailUpdate
    {
        [Required]
        [MinLength
            (2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength
            (100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string Subject { get; set; }
        public string Body { get; set; }
        [Required]
        [MaxLength
            (8000, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public int ReceiverId { get; set; }
        public int SenderId { get; set; }
        public int BoxId { get; set; }
    }
}