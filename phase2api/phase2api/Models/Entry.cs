﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace phase2api.Models
{
    public class Entry
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntryId { get; set; }

        [Required]
        public string Mood { get; set; }

        [Required]
        public string MoodContext { get; set; }

        [Required]
        public string OnePositive { get; set; }

        [Required]
        public int DiaryId { get; set; }



    }

}
