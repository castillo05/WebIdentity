namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class formatos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public formatos()
        {
            pagos = new HashSet<pagos>();
        }

        [Key]
        public int id_formato { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_f { get; set; }

        public double valor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pagos> pagos { get; set; }

        //Listando Formatos para pagos
        public List<formatos> Listar_Formato()
        {
            var formato = new List<formatos>();
            try
            {
                using (var ctx = new ImiContext())
                {
                    formato=ctx.formatos.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return formato;
        }


    }
}
