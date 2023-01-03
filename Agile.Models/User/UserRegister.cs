using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Models.User
{
    public class UserRegister
    {
        [Required]
        [MinLength(1, ErrorMessage = "{0} must have at least {1} ")]
        public string UserName { get; set; }

        public string EmailAddress {get; set;}
    }
}