namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Slider
    {
        public int id { get; set; }

        [StringLength(50)]
        [DisplayName("Title")]
        [Required(ErrorMessage = "Title không được để trống!")]
        public string name { get; set; }

        [StringLength(255)]
        [DisplayName("Ảnh bìa")]
        public string imagePath { get; set; }

        [StringLength(255)]
        [DisplayName("Đường dẫn")]
        public string urlPath { get; set; }
    }
}
