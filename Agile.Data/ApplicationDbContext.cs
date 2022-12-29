using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agile.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Agile.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Box> Boxes {get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Mail> Mail {get; set;}
    }
}