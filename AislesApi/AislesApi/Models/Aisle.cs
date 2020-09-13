using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AislesAPI.Models
{
    public class Aisle
    {
        public Aisle()
        {
            AisleSections = new HashSet<AisleSection>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AisleId { get; set; }

        [Required]
        public string AisleName { get; set; }

        public virtual ICollection<AisleSection> AisleSections { get; set; }
    }
}
