namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("actividad")]
    public partial class actividad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public actividad()
        {
            negocio = new HashSet<negocio>();
        }

        [Key]
        public int id_actividad { get; set; }

        [Column("actividad")]
        [Required]
        [StringLength(50)]
        public string actividad1 { get; set; }

       
        public virtual ICollection<negocio> negocio { get; set; }


        public List<actividad> Listar_Actividad()
        {
            var act = new List<actividad>();
            try
            {
                using (var ctx = new ImiContext())
                {
                    act = ctx.actividad.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return act;
        }
    }
}
