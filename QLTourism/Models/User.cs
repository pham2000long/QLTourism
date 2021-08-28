namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trống!")]
        [StringLength(50)]
        [DisplayName("Tên tài khoản")]
        public string username { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [StringLength(255)]
        [DisplayName("Mật khẩu")]
        public string password { get; set; }

        [StringLength(255)]
        [DisplayName("Tên nhân viên")]
        public string name { get; set; }

        [StringLength(255)]
        [DisplayName("Email")]
        public string email { get; set; }

        [StringLength(20)]
        [DisplayName("Số điện thoại")]
        public string phone { get; set; }

        [DisplayName("Giới tính")]
        public bool? gender { get; set; }

        [StringLength(255)]
        [DisplayName("Ảnh đại diện")]
        public string avatar { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Ngày sinh")]
        public DateTime? birthday { get; set; }

        [StringLength(255)]
        [DisplayName("Địa chỉ")]
        public string address { get; set; }

        [DisplayName("Quyền hạn")]
        public int? roleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
