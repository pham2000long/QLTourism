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

        public int? Price { get; set; }

        [StringLength(255)]
        public string customerNote { get; set; }

        public int? bookingId { get; set; }

        public int? packageId { get; set; }

        public int? comboCount { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Package Package { get; set; }
    }
}
