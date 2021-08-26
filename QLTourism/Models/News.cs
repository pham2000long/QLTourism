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
        public int id { get; set; }

        [Required(ErrorMessage = "Tên tin tức không được để trống!")]
        [StringLength(255)]
        [DisplayName("Tên tin tức")]
        public string title { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày viết")]
        public DateTime? date { get; set; }

        [StringLength(255)]
        [DisplayName("Tóm tắt")]
        public string summary { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung tin tức")]
        public string detail { get; set; }

        [DisplayName("Mã danh mục")]
        public int categoryId { get; set; }

        [StringLength(255)]
        [DisplayName("Ảnh bìa")]
        public string thumbail { get; set; }

        public virtual Category Category { get; set; }
    }
}
