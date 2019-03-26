using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Database : DbContext
    {
        public Database() : base("DefaultConnection")
        {
            //Database.CreateIfNotExists();
            //Database.Initialize(true);
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
    }
}