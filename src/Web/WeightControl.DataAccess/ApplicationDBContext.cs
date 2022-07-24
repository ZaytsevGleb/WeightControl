using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
