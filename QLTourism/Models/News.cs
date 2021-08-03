namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        public string title { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        public string summary { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        public int categoryId { get; set; }

        [StringLength(255)]
        public string thumbail { get; set; }

        public virtual Category Category { get; set; }
    }
}
