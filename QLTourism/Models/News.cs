namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Mã tin tức")]
        public int id { get; set; }

        [StringLength(255)]
        [DisplayName("Tiêu đề tin tức")]
        public string title { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày đăng tin")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        [DisplayName("Nội dung tóm tắt")]
        public string summary { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung chi tiết")]
        public string detail { get; set; }

        [DisplayName("Mã danh mục")]
        public int categoryId { get; set; }

        [StringLength(255)]
        [DisplayName("Ảnh tiêu đề")]
        public string thumbail { get; set; }

        public virtual Category Category { get; set; }
    }
}
