using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agile.Models.User
{
    public class UserUpdate
    {
        [Required]
        public int Id {get; set;}
        //the only changeable field right now will be their name
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long")]
        public string UserName {get; set;}
    }
}