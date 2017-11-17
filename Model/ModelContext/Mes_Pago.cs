namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Mes_Pago
    {
        public int id { get; set; }

        public int id_pago_mes { get; set; }

        public int id_mes_pago { get; set; }

        public virtual meses meses { get; set; }

        public virtual pagos pagos { get; set; }


        public List<Mes_Pago> Listar_mes()
        {
            var mes = new List<Mes_Pago>();
            try
            {
                using (var ctx = new ImiContext())
                {
                    mes = ctx.Mes_Pago.ToList();
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
