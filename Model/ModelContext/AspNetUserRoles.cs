namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AspNetUserRoles
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public string RoleId { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public virtual AspNetRoles AspNetRoles { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
