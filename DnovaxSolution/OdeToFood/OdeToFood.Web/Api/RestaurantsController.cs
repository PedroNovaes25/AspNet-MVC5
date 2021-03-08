﻿using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OdeToFood.Web.Api
{
    public class RestaurantsController : ApiController
    {
        private IRestaurantData restaurantContext;

        public RestaurantsController(IRestaurantData restaurantData)
        {
            this.restaurantContext = restaurantData;
        }

        public IHttpActionResult Get()
        {
            return Json(restaurantContext.GetAll());
        }

    }
}
