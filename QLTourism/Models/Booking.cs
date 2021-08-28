namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Booking()
        {
            BookingDetails = new HashSet<BookingDetail>();
        }

        public int id { get; set; }

        [DisplayName("Ngày đặt tour")]
        public DateTime? bookingDate { get; set; }

        [DisplayName("Mã đơn hàng")]
        [StringLength(50)]
        public string bookingNo { get; set; }

        public int? customerId { get; set; }

        [StringLength(255)]
        [DisplayName("Quốc gia")]
        public string country { get; set; }

        [StringLength(255)]
        [DisplayName("Thành phố")]
        public string city { get; set; }

        [StringLength(255)]
        [DisplayName("Địa chỉ")]
        public string address { get; set; }

        [StringLength(255)]
        [DisplayName("Ghi chú của khách hàng")]
        public string customerNote { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
