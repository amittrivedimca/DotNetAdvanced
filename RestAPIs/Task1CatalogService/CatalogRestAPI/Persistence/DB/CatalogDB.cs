using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DB
{
    public class CatalogDB : DbContext
    {
        public CatalogDB(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
