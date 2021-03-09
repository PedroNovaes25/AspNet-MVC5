using OdeToFood.Data.Models;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class RestaurantsController : Controller
    {

        private readonly IRestaurantData restaurantContext;

        public RestaurantsController(IRestaurantData restaurantData)
        {
            this.restaurantContext = restaurantData;
        }

        [HttpGet]
        public ActionResult Index()  
        {
            var model = restaurantContext.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id) 
        {
            var model = restaurantContext.GetById(id);

            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Evita a falsicação de formulários
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurantContext.AddRestaurant(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            var model = restaurantContext.GetById(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]//Evita a falsicação de formulários
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                restaurantContext.UpdateRestaurant(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });
            }
            return View();
        }
    }

    
}