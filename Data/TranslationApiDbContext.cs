using Dictionary_Test.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dictionary_Test.Data
{
    public class TranslationApiDbContext : DbContext
    {
        public TranslationApiDbContext( DbContextOptions options) : base(options)
        {
        }

        public DbSet<Translation> Translation  { get; set; }
    }
}
