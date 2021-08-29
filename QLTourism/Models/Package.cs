namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Script.Serialization;

    public partial class Package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package()
        {
            BookingDetails = new HashSet<BookingDetail>();
            Media = new HashSet<Medium>();
            Prices = new HashSet<Price>();
            Programs = new HashSet<Program>();
        }

        public int id { get; set; }

        [Required(ErrorMessage = "Tên tour không được để trống!")]
        [StringLength(255)]
        [DisplayName("Tên tour du lịch")]
        public string pkgName { get; set; }

        [DisplayName("Ngày bắt đầu")]
        [Required(ErrorMessage = "Ngày bắt đầu không được để trống!")]
        [Column(TypeName = "date")]
        public DateTime? pkgStartDate { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Thời gian diễn ra không được để trống!")]
        [DisplayName("Thời gian diễn ra")]
        public string pkgTimePeriod { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Điểm xuất phát không được để trống!")]
        [DisplayName("Điểm xuất phát")]
        public string pkgStartPlace { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Điểm đến không được để trống!")]
        [DisplayName("Điểm đến")]
        public string pkgEndPlace { get; set; }

        [Column(TypeName = "ntext")]
        [DisplayName("Mô tả")]
        public string pkgDesc { get; set; }

        [StringLength(255)]
        [DisplayName("Quy định")]
        public string pkgRules { get; set; }

        [StringLength(255)]
        [DisplayName("Phương tiện")]
        public string pkgTransporter { get; set; }

        [DisplayName("Giá cơ bản")]
        [Required(ErrorMessage = "Giá cơ bản không được để trống!")]
        public int pkgBasePrice { get; set; }

        [StringLength(255)]
        [DisplayName("Điều kiện")]
        public string pkgCondition { get; set; }

        [DisplayName("Vị trí trống")]
        [Required(ErrorMessage = "Vị trí trống không được để trống!")]
        public int? pkgSlot { get; set; }

        [DisplayName("Trạng thái")]
        public int? active { get; set; }

        [DisplayName("Mã danh mục")]
        public int? categoryId { get; set; }

        [StringLength(255)]
        [DisplayName("Ảnh bìa")]
        public string thumbail { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }

        public virtual Category Category { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medium> Media { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price> Prices { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
    }
}