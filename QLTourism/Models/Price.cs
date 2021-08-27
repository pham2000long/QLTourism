namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    public partial class Price
    {
        public int id { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [Column("price")]
        public int? price1 { get; set; }

        public int? packageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
