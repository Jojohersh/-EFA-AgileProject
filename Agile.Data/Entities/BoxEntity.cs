using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Agile.Data.Entities;

namespace Agile.Data.Entities
{
    public class BoxEntity
    {
        [Key]
        public int Id {get; set;} 
        [Required]
        public string BoxName {get; set;}

        [Required]
        [ForeignKey (nameof(User))]
        public int UserId {get; set;}
        public UserEntity User {get; set;}
        
    }
}