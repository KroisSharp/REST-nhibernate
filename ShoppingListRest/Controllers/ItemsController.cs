using ShoppingListRest.Controllers.Respository;
using ShoppingListRest.Models.DatabaseConnection.Hibernate;
using ShoppingListRest.Models.Entities;
using ShoppingListRest.Models.Respository.Hibernate;
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

        private readonly IItemRespository _itemRespository;
        public ItemsController()
        {
            var connection = new ShoppingListDBConenection();
            _itemRespository = new ItemRespository(connection);
        }


        [HttpGet]
        [Route("api/items/{uid}")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetItems(string uid)
        {

            var items = _itemRespository.GetItemsByUID(uid);

            //TODO: listen skal hentes og skal hentes genenm interface etc
            return Ok(items);
        }

    }
}
