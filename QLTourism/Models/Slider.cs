namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slider
    {
        [Required(ErrorMessage ="Id không được để trống!")]
        public int id { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Name không được để trống!")]
        public string name { get; set; }

        [StringLength(255)]
        public string imagePath { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Url không được để trống!")]
        public string urlPath { get; set; }
    }
}
