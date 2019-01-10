using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListRest.Models.Entities
{
    public class Item
    {
        public virtual int Id { get; set; }
        public virtual string UID { get; set; }
        public virtual string Name { get; set; }
        public virtual double Price { get; set; }
        public virtual Category Category { get; set; }
    }
}