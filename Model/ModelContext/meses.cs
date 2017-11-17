namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class meses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public meses()
        {
            Mes_Pago = new HashSet<Mes_Pago>();
        }

        [Key]
        public int id_mes { get; set; }

        [Required]
        [StringLength(50)]
        public string Mes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Mes_Pago> Mes_Pago { get; set; }


        public List<meses> Listar_meses()
        {
            var mes = new List<meses>();
            try
            {
                using (var ctx = new ImiContext())
                {
                    mes = ctx.meses.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return mes;
        }

    }
}
