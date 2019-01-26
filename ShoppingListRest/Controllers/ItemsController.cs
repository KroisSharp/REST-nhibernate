using Newtonsoft.Json.Linq;
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


        #region Get Items
        [HttpGet]
        [Route("api/items/{uid}")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetItems(string uid)
        {

            //does user exist
            if (!_itemRespository.UserOk(uid))
            {
                dynamic jsonObejct = new JObject();
                var HttpStatus = HttpStatusCode.Unauthorized;
                jsonObejct.status = (int)HttpStatus;
                jsonObejct.message =
                    "The request has not been applied because it lacks valid authentication credentials for the target resource.";
                return Content(HttpStatus, jsonObejct);
            }

            //get list by uid
            var items = _itemRespository.GetItemsByUID(uid);
            //check if there is items to return
            if (items.Count < 0)
            {
                dynamic jsonObject = new JObject();
                var HttpStatus = HttpStatusCode.NoContent;
                jsonObject.status = (int)HttpStatus;
                jsonObject.message =
                    "The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.";
                return Content(HttpStatus, jsonObject);
            }


            //return items
            return Ok(items);

        }
        #endregion


        [HttpPost]
        [Route("api/items/")]
        [ResponseType(typeof(string))]
        public IHttpActionResult PostItem(Item item)
        {

            //does user exist
            if (!_itemRespository.UserOk(item.UID))
            {
                dynamic jsonObejct = new JObject();
                var HttpStatus = HttpStatusCode.Unauthorized;
                jsonObejct.status = (int)HttpStatus;
                jsonObejct.message =
                    "The request has not been applied because it lacks valid authentication credentials for the target resource.";
                return Content(HttpStatus, jsonObejct);
            }

            //post
            if (item.UID != null)
            {
                _itemRespository.PostItem(item);
            }


            return Ok(item);

        }

    }
}
