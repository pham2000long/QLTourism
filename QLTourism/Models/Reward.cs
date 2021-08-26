namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reward
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reward()
        {
            Customers_Rewards = new HashSet<Customers_Rewards>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(255)]
        [DisplayName("Tên khuyến mại")]
        [Required(ErrorMessage = "Tên khuyến mại không được để trống!")]
        public string rwdName { get; set; }

        [StringLength(255)]
        [DisplayName("Mô tả")]
        public string rwdDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customers_Rewards> Customers_Rewards { get; set; }
    }
}
