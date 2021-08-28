namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Medium
    {
        public int id { get; set; }

        [DisplayName("Kiểu dữ liệu")]
        public int type { get; set; }

        [StringLength(255)]
        [DisplayName("Đường dẫn")]
        public string path { get; set; }

        [DisplayName("Mã tour")]
        public int packageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
