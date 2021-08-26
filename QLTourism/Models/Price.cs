namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Price
    {
        public int id { get; set; }

        [StringLength(255)]
        [DisplayName("Title")]
        [Required(ErrorMessage = "Title kh�ng ???c ?? tr?ng!")]
        public string title { get; set; }

        [Column("price")]
        [DisplayName("Gi�")]
        public int? price1 { get; set; }

        [DisplayName("M� tour")]
        public int? packageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
