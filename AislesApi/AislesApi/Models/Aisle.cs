using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AislesApi.Models
{
    public class Aisle
    {

        public int AisleID { get; set; }
        public string AisleName { get; set; }


        public virtual ICollection<Item> Items { get; set; }

    }
}
