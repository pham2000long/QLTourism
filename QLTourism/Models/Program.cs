namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Program
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [StringLength(255)]
        public string summary { get; set; }

        [StringLength(255)]
        public string detail { get; set; }

        public int? packageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
