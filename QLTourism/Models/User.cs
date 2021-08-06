namespace QLTourism.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class User
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Username không được để trống")]
        [StringLength(50)]
        public string username { get; set; }

        [Required(ErrorMessage = "Password không được để trống")]
        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        public bool? gender { get; set; }

        [StringLength(255)]
        public string avatar { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        public int? roleId { get; set; }

        public virtual Role Role { get; set; }

    }
}
