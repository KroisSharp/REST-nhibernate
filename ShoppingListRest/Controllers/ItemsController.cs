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

        #region Post
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
            if (item.UID != null && _itemRespository.UserOk(item.UID))
            {
                _itemRespository.PostItem(item);
            }


            return Ok(item);

        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("api/items/")]
        [ResponseType(typeof(string))]
        public IHttpActionResult DeleteItem(Item item)
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

            //tilhøre ID -> firebase id
            if (!_itemRespository.DoesIDMatchUID(item.UID,item.Id))
            {
                dynamic jsonObejct = new JObject();
                var HttpStatus = HttpStatusCode.Unauthorized;
                jsonObejct.status = (int)HttpStatus;
                jsonObejct.message =
                    "The request has not been applied because it lacks valid authentication credentials for the target resource.";
                return Content(HttpStatus, jsonObejct);
            }

            _itemRespository.DeleteItem(item);
            return StatusCode(HttpStatusCode.Accepted);

        }
        #endregion

        #region PUT
        [HttpPut]
        [Route("api/items/")]
        [ResponseType(typeof(string))]
        public IHttpActionResult PutItem(Item item)
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


            //tilhøre ID -> firebase id
            if (!_itemRespository.DoesIDMatchUID(item.UID, item.Id))
            {
                dynamic jsonObejct = new JObject();
                var HttpStatus = HttpStatusCode.Unauthorized;
                jsonObejct.status = (int)HttpStatus;
                jsonObejct.message =
                    "The request has not been applied because it lacks valid authentication credentials for the target resource.";
                return Content(HttpStatus, jsonObejct);
            }

            //put
            if (item == null)
            {
                dynamic jsonObejct = new JObject();
                var HttpStatus = HttpStatusCode.BadRequest;
                jsonObejct.status = (int)HttpStatus;
                jsonObejct.message =
                    "The server cannot or will not process the request due to something that is perceived to be a client error";
                return Content(HttpStatus, jsonObejct);
            }

            _itemRespository.PutItem(item);
            return Ok(item);

        }
        #endregion

    }
}
