namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customers_Rewards
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int customerId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int rewardId { get; set; }

        [Required]
        [StringLength(25)]
        public string rwdNumber { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Reward Reward { get; set; }
    }
}
