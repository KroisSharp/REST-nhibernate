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
        Item PostItem(Item item);
        void DeleteItem(Item item);
        Item PutItem(Item item);


        
        Boolean UserOk(string uid);
        Boolean DoesIDMatchUID(string uid, int id);

        

    }
}