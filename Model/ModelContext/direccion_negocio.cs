namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class direccion_negocio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public direccion_negocio()
        {
            negocio = new HashSet<negocio>();
        }

        [Key]
        public int id_direccion { get; set; }

        [Required]
        [StringLength(50)]
        public string zona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<negocio> negocio { get; set; }


        public List<direccion_negocio> Listar_Direccion()
        {
            var dir = new List<direccion_negocio>();
            try
            {

                using (var ctx = new ImiContext())
                {
                    dir = ctx.direccion_negocio.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dir;
        }


    }
}
