using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListRest.Models.Entities
{
    public class Category
    {

        public virtual int Id { get; set; }
        public virtual string Department { get; set; }


    }
}