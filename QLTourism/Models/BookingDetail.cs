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

        [DisplayName("Tổng tiền")]
        public int? Price { get; set; }

        [DisplayName("Mã booking")]
        public int? bookingId { get; set; }

        [DisplayName("Mã tour")]
        public int? packageId { get; set; }

        [StringLength(255)]
        [DisplayName("Thông tin đặt tour")]
        public string bookingInfor { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Package Package { get; set; }
    }
}
