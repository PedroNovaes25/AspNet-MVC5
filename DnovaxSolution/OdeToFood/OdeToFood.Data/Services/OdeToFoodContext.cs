using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class OdeToFoodContext : DbContext
    {

        //public OdeToFoodContext(string connectionStringName)
        //   : base("name=" + connectionStringName)
        //{
        //    Configuration.ProxyCreationEnabled = false;
        //    Database.SetInitializer<OdeToFoodContext>(null);
        //}

        public DbSet<Restaurant> Restaurant { get; set; }
    }
}
