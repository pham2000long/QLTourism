namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookingDetail
    {
        public int id { get; set; }

        [DisplayName("Ngày bắt đầu")]
        [Required(ErrorMessage = "Ngày bắt đầu không được để trống!")]
        public DateTime? tripStart { get; set; }

        [DisplayName("Ngày kết thúc")]
        [Required(ErrorMessage = "Ngày kết thúc không được để trống!")]
        public DateTime? tripEnd { get; set; }

        [StringLength(255)]
        [DisplayName("Mô tả chi tiết")]
        public string description { get; set; }

        [StringLength(255)]
        [DisplayName("Điểm đến")]
        [Required(ErrorMessage = "Điểm đến không được để trống!")]
        public string destination { get; set; }

        [DisplayName("Giá")]
        [Required(ErrorMessage = "Giá không được để trống!")]
        public int? Price { get; set; }

        [StringLength(255)]
        [DisplayName("Ghi chú của khách")]
        public string customerNote { get; set; }

        [DisplayName("Mã đặt tour")]
        public int? bookingId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
