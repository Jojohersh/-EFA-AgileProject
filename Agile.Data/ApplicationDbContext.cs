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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<BoxEntity> Boxes {get; set;}
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<MailEntity> Mail {get; set;}
    }
}