using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListRest.Models.Entities
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string UID { get; set; }
        public virtual string Email { get; set; }
    }
}