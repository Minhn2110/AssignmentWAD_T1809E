using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WAD.Models
{
    public class MyDatabaseContext : DbContext
    {
        public MyDatabaseContext() : base("MyConnectionString")
        {

        }

        public DbSet<Product> ProductsChild { get; set; }
        public DbSet<Category> CategoriesChild { get; set; }

    }
}