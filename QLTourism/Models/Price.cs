namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Price
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [Column("price", TypeName = "money")]
        public decimal? price1 { get; set; }

        public int? packageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
