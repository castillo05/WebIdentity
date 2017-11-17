namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.SqlClient;
    using System.Linq;



    [Table("negocio")]
    public partial class negocio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public negocio()
        {
            pagos = new HashSet<pagos>();
        }

        [Key]
        public int id_n { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre_n { get; set; }

        [Required]
        [Editable(true)]
        
        public int num_mat { get; set; }

        [Required]
        [StringLength(128)]

        public string id_cont_negocio { get; set; }

        [Required]
        public int id_direccion { get; set; }

        [Required]
        public int id_actividad { get; set; }

        public virtual actividad actividad { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual direccion_negocio direccion_negocio { get; set; }

       
        public virtual ICollection<pagos> pagos { get; set; }


        //public List<negocio> Listar_Negocio()
        //{
        //    var neg = new List<negocio>();
        //    try
        //    {
        //        using (var ctx = new ImiContext())
        //        {
        //            var nego = ctx.AspNetUsers.Where(x => x.Id == id_cont_negocio)
        //                                       .Select(x => x.Id)
        //                                       .ToList();

        //            neg = ctx.negocio.Where(x => nego.Contains(x.id_cont_negocio)).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return neg;
        //}





            //Obtener los negocios

        public negocio Obtener(int id)
        {
            var neg = new negocio();
            try
            {
                using (var ctx = new ImiContext())
                {
                    neg = ctx.negocio.Include("actividad")
                                            .Include("AspNetUsers")
                                            .Include("direccion_negocio")
                                            .Include("pagos")
                                            .Where(x => x.id_n == id)
                                            .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return neg;
        }

        // Listar Negocios
        public List<negocio> Listar_Negocios(int Id=0)
        {
            var mes = new List<negocio>();
            try
            {
                using (var ctx = new ImiContext())
                {
                    mes = ctx.negocio.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return mes;
        }
        //public negocio Obtener(string id)
        //{
        //    var neg = new negocio();
        //    try
        //    {
        //        using (var ctx = new ImiContext())
        //        {
        //            neg = ctx.negocio.Include("actividad")
        //                                    .Include("AspNetUsers")
        //                                    .Include("direccion_negocio")
        //                                    .Include("pagos")
        //                                    .Where(x => x.id_cont_negocio == id )
        //                                    .FirstOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return neg;
        //}


        //Guardar Negocio
        public void Guardar(int mat=0)
        {
            try
            {
             
                        using (var ctx = new ImiContext())
                        {

                    ctx.Database.ExecuteSqlCommand(
                        "select * from negocio where num_mat=@mat",
                        new SqlParameter("mat",this.num_mat)
                     );
                            if (this.id_n == 0)
                            {
                                ctx.Entry(this).State = System.Data.Entity.EntityState.Added;
                            }
                            else
                            {
                                 ctx.Entry(this).State = System.Data.Entity.EntityState.Modified;
                            }
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
