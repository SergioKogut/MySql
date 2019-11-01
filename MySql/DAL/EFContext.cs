using Microsoft.EntityFrameworkCore;
using MySql.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySql.DAL
{
    public class EFContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
           : base(options)
        {

        }
        

    }
}
