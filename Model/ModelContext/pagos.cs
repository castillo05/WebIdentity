namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;
    using System.Linq;

    public partial class pagos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pagos()
        {
            Mes_Pago = new HashSet<Mes_Pago>();
        }

        [Key]
        public int id_pago { get; set; }

        [Required]
        [StringLength(50)]
        public string concepto { get; set; }

        [Required]
        public int id_negocio { get; set; }

        [Required]
        [StringLength(50)]
        public string fecha { get; set; }

        [Required]
        [StringLength(128)]
        public string id_colector { get; set; }

        [Required]
        [StringLength(50)]
        public string tipo_pago { get; set; }

        [Required]
        public double monto { get; set; }
        [Required]
        public double total_pago { get; set; }
        [Required]
        public int id_formato { get; set; }
        [Required]
        public int id_tributo { get; set; }

        public virtual formatos formatos { get; set; }

       
        public virtual ICollection<Mes_Pago> Mes_Pago { get; set; }

        public virtual negocio negocio { get; set; }

        public virtual tributos tributos { get; set; }


        //Listar Pagos Para Mostrar los realizados
        public List<pagos> Listar_pagos(int id =0)
        {
            var pago = new List<pagos>();
            try
            {
                using (var ctx = new ImiContext())
                {
                    pago = ctx.pagos.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return pago;
        }




        //Obtener pagos de negocios
        public pagos Obtener(int id)
        {
            var neg = new pagos();
            try
            {
                using (var ctx = new ImiContext())
                {
                    neg = ctx.pagos.Include("Mes_Pago")
                                            .Include("negocio")
                                            .Include("tributos")
                                            .Where(x => x.id_negocio == id)
                                            .FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return neg;
        }


        //Metodo para guardar pago
        public void Guardar_Pago(int mat = 0)
        {
            try
            {

                using (var ctx = new ImiContext())
                {
                    
                   
                        ctx.Entry(this).State = System.Data.Entity.EntityState.Added;
                   
                    ctx.SaveChanges();

                }


            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
