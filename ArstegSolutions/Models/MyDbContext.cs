using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArstegSolutions.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=ArstegSolutionConStr") { }
        public DbSet<TaxSlab> TaxSlabs { get; set; }
    }
}