using ApiWebTest.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWebTest.Context
{
    public class DataContext: DbContext
    {
      

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
            
        }


        public DbSet<Humano> Humano { get; set; }
    }
}
