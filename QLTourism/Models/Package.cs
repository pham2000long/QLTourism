namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Package
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Package()
        {
            Bookings = new HashSet<Booking>();
            Media = new HashSet<Medium>();
            Prices = new HashSet<Price>();
            Programs = new HashSet<Program>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string pkgName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? pkgStartDate { get; set; }

        [StringLength(255)]
        public string pkgTimePeriod { get; set; }

        [StringLength(255)]
        public string pkgStartPlace { get; set; }

        [StringLength(255)]
        public string pkgEndPlace { get; set; }

        [Column(TypeName = "ntext")]
        public string pkgDesc { get; set; }

        [StringLength(255)]
        public string pkgRules { get; set; }

        [StringLength(255)]
        public string pkgTransporter { get; set; }

        public int pkgBasePrice { get; set; }

        [StringLength(255)]
        public string pkgCondition { get; set; }

        public int? pkgSlot { get; set; }

        public int? active { get; set; }

        public int? categoryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Medium> Media { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price> Prices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
    }
}
