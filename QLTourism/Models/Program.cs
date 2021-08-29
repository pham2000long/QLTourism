namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Program
    {
        public int id { get; set; }

        [StringLength(255)]
        [DisplayName("Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống!")]
        public string title { get; set; }

        [StringLength(255)]
        [DisplayName("Mô tả")]
        public string summary { get; set; }

        [StringLength(255)]
        [DisplayName("Mô tả chi tiết")]
        public string detail { get; set; }

        [DisplayName("Mã tour")]
        public int? packageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
