namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public int? customerId { get; set; }

        public int? membershipId { get; set; }

        public int? roleId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Membership Membership { get; set; }

        public virtual Role Role { get; set; }
    }
}
