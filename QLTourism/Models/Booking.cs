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
        [Required(ErrorMessage = "Ngày đặt tour không được để trống!")]
        [DisplayName("Ngày đặt tour")]
        public DateTime? bookingDate { get; set; }

        [Required(ErrorMessage = "Mã đặt tour không được để trống!")]
        [StringLength(50)]
        [DisplayName("Mã đặt tour")]
        public string bookingNo { get; set; }

        [Required(ErrorMessage = "Số người không được để trống!")]
        [DisplayName("Số người")]
        public int? travelerCount { get; set; }

        [DisplayName("Mã khách hàng")]
        public int? customerId { get; set; }

        [StringLength(1)]
        [DisplayName("Mã loại tour")]
        public string tripTypeId { get; set; }

        [DisplayName("Mã tour")]
        public int? packageId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Package Package { get; set; }

        public virtual TripType TripType { get; set; }
    }
}
