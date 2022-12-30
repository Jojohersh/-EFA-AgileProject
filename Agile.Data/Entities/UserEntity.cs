using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Agile.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agile.Data.Entities
{

  public class UserEntity
  {
    [Key]
    public int Id {get; set;}

    [Required]
    public string UserName {get; set;}

    [Required]
    [EmailAddress]
    public string EmailAddress {get; set;}

    [Required]
    [ForeignKey(nameof(inbox))]
    public int InboxId {get; set;}
    public BoxEntity inbox {get; set;}
  }
}
