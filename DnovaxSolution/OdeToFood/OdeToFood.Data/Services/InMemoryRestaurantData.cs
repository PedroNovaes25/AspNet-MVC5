using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {

        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Scott's Pizza", Cuisine = CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Tersiguels", Cuisine = CuisineType.French},
                new Restaurant { Id = 3, Name = "Mango Grove", Cuisine = CuisineType.Indian},
                new Restaurant { Id = 4, Name = "Madero", Cuisine = CuisineType.Brazilian}
            };
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Max(x => x.Id) + 1;
            restaurants.Add(restaurant);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(x => x.Name);
        }

        public Restaurant GetById(int id)
        {
            return restaurants.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            var restaurantNew = GetById(restaurant.Id);

            if (restaurantNew != null)
            {
                restaurantNew.Name = restaurant.Name;
                restaurantNew.Cuisine = restaurant.Cuisine;
            }
        }
    }
}
