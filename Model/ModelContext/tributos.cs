namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tributos
    {
       
        public tributos()
        {
            pagos = new HashSet<pagos>();
        }

        [Key]
        public int id_tributo { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_t { get; set; }

        [Required]
        [StringLength(50)]
        public string codigo_t { get; set; }

        
        public virtual ICollection<pagos> pagos { get; set; }

        public List<tributos> ListarTributos()
        {
            var trib = new List<tributos>();
            try
            {
                using (var ctx = new ImiContext())
                {
                    trib = ctx.tributos.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return trib;
        }



    }
}
