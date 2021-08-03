namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medium
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int type { get; set; }

        [StringLength(255)]
        public string path { get; set; }

        public int packageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
