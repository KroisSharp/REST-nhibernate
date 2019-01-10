using ShoppingListRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ShoppingListRest.Controllers
{
    public class ItemsController : ApiController
    {


        //senere DB nu staic list
        private static List<Item> Items = new List<Item>
        {
            new Item{Id = 1, Name = "ost", Price = 20.95, UID = "FireBaseUID", Category = new Category{Id = 1, Department = "Mejeri"}},
            new Item{Id = 2, Name = "smør", Price = 20.95, UID = "FireBaseUID", Category = new Category{Id = 1, Department = "Mejeri"}},
            new Item{Id = 3, Name = "mælk", Price = 20.95, UID = "FireBaseUID", Category = new Category{Id = 1, Department = "Mejeri"}},
            new Item{Id = 4, Name = "æg", Price = 20.95, UID = "FireBaseUID", Category = new Category{Id = 1, Department = "Mejeri"}},
            new Item{Id = 5, Name = "yoghurt", Price = 20.95, UID = "FireBaseUID", Category = new Category{Id = 1, Department = "Mejeri"}},
            new Item{Id = 6, Name = "feta", Price = 20.95, UID = "FireBaseUID", Category = new Category{Id = 1, Department = "Mejeri"}},

        };



        [HttpGet]
        [Route("api/items/{uid}")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetItems(string uid)
        {

            var items = "hej";

            //TODO: listen skal hentes og skal hentes genenm interface etc
            return Ok(Items);
        }

    }
}
