namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookingDetail
    {
        public int id { get; set; }

        public double? itineraryNo { get; set; }

        public DateTime? tripStart { get; set; }

        public DateTime? tripEnd { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string destination { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(10)]
        public string customerNote { get; set; }

        public int? bookingId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
