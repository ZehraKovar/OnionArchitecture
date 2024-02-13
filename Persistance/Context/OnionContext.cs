using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class OnionContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conString= "Host=localhost;Port=5432;Database=OnionArchitecture;Username=postgres;Password=qawsedrf";
            optionsBuilder.UseNpgsql(conString);
        }
        public DbSet<Book> Books { get; set; }
    }
}
