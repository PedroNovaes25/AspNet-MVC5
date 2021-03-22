using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        //private string connectionString;
        //public SqlRestaurantData(string connectionString = "FloatConnection")
        //{
        //    this.connectionString = connectionString;
        //}

        private readonly OdeToFoodContext dbContext;

        public SqlRestaurantData(OdeToFoodContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void AddRestaurant(Restaurant restaurant)
        {
            //using (OdeToFoodContext dao = new OdeToFoodContext(connectionString))
            //{
            //    dao.Set<Restaurant>().Add(restaurant);
            //savechanges
            //}

            dbContext.Restaurant.Add(restaurant);
            dbContext.SaveChanges();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return dbContext.Restaurant.Select(x =>x).OrderBy(x => x.Name);
        }

        public Restaurant GetById(int id)
        {
            return dbContext.Restaurant.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            var entry = dbContext.Entry(restaurant);
            entry.State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
