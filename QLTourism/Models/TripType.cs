namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TripType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TripType()
        {
            Bookings = new HashSet<Booking>();
        }

        [Required(ErrorMessage = "Mã loại tour không được để trống!")]
        [StringLength(1)]
        [DisplayName("Mã loại tour")]
        public string id { get; set; }

        [Required(ErrorMessage = "Tên loại tour không được để trống!")]
        [StringLength(25)]
        [DisplayName("Tên loại tour")]
        public string ttName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
