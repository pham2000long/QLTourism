namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    public partial class Package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package()
        {
            Bookings = new HashSet<Booking>();
            Media = new HashSet<Medium>();
            Prices = new HashSet<Price>();
            Programs = new HashSet<Program>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "Không được để trống tên")]
        [DisplayName("Tên tour")]
        [StringLength(255)]
        public string pkgName { get; set; }

        [DisplayName("Ngày khởi hành")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Column(TypeName = "date")]
        public DateTime? pkgStartDate { get; set; }

        [DisplayName("Thời gian")]
        [StringLength(255)]
        public string pkgTimePeriod { get; set; }

        [DisplayName("Điểm khởi hành")]
        [StringLength(255)]
        public string pkgStartPlace { get; set; }

        [DisplayName("Điểm kết thúc")]
        [StringLength(255)]
        public string pkgEndPlace { get; set; }

        [DisplayName("Chi tiết")]
        [Column(TypeName = "ntext")]
        public string pkgDesc { get; set; }

        [DisplayName("Quy định")]
        [StringLength(255)]
        public string pkgRules { get; set; }

        [DisplayName("Phương tiện")]
        [StringLength(255)]
        public string pkgTransporter { get; set; }

        [DisplayName("Giá cơ bản")]
        public int pkgBasePrice { get; set; }

        [DisplayName("Điều kiện")]
        [StringLength(255)]
        public string pkgCondition { get; set; }

        [DisplayName("Chỗ")]
        public int? pkgSlot { get; set; }

        [DisplayName("Kích hoạt")]
        public int? active { get; set; }

        public int? categoryId { get; set; }

        [DisplayName("Ảnh")]
        [StringLength(255)]
        public string thumbail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medium> Media { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price> Prices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
    }
}
