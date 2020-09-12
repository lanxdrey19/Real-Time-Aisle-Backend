using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AislesApi.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemType { get; set; }
        public bool IsAvailable { get; set; }
        public int AisleID { get; set; }
        public virtual Aisle theirAisle { get; set; }
    }
}
