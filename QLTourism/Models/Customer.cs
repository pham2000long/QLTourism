namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Bookings = new HashSet<Booking>();
            Customers_Rewards = new HashSet<Customers_Rewards>();
        }

        public int id { get; set; }

        [StringLength(100)]
        [DisplayName("Tên tài khoản")]
        [Required(ErrorMessage = "Tên tài khoản không được để trống!")]
        public string username { get; set; }

        [StringLength(255)]
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        public string password { get; set; }

        [StringLength(255)]
        [DisplayName("Tên khách hàng")]
        public string name { get; set; }

        [StringLength(255)]
        [DisplayName("Email")]
        public string email { get; set; }

        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string phone { get; set; }

        [DisplayName("Giới tính")]
        public bool? gender { get; set; }

        [Required(ErrorMessage = "Thành phố không được để trống!")]
        [DisplayName("Thành phố")]
        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        [DisplayName("Quốc gia")]
        public string country { get; set; }

        [StringLength(255)]
        [DisplayName("Ảnh đại diện")]
        public string avatar { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime? birthday { get; set; }

        [StringLength(255)]
        [DisplayName("Địa chỉ")]
        public string address { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customers_Rewards> Customers_Rewards { get; set; }
    }
}
