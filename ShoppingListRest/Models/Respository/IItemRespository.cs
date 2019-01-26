using ShoppingListRest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListRest.Controllers.Respository
{
    public interface IItemRespository
    {
        IList<Item> GetItemsByUID(string uid);

        Boolean UserOk(string uid);

        Item PostItem(Item item);

    }
}