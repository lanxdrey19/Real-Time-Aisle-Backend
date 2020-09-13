using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AislesAPI.Models
{
    public class AisleSection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AisleSectionId { get; set; }

        public string AisleSectionName { get; set; }

        [ForeignKey("Aisle")]
        public int AisleId { get; set; }


    }
}
