namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slider
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(255)]
        public string imagePath { get; set; }

        [StringLength(255)]
        public string urlPath { get; set; }
    }
}
