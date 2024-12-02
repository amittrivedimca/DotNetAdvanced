using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DB
{
    public class DbInitializer
    {
        public static void Initialize(CatalogDB dbContext)
        {
            if(!dbContext.Categories.Any())
            {
                dbContext.Categories.Add(new Category()
                {
                    Name = "Category1"
                });
                dbContext.Categories.Add(new Category()
                {
                    Name = "Category2"
                });                
                dbContext.SaveChanges();
            }            
        }


    }
}
