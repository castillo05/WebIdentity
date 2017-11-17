namespace Model.ModelContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class AspNetUsers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AspNetUsers()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaims>();
            AspNetUserLogins = new HashSet<AspNetUserLogins>();
            AspNetUserRoles = new HashSet<AspNetUserRoles>();
            negocio = new HashSet<negocio>();
        }

        public string Id { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string Discriminator { get; set; }

        public string Cedula { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserClaims> AspNetUserClaims { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserLogins> AspNetUserLogins { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AspNetUserRoles> AspNetUserRoles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<negocio> negocio { get; set; }




        public List<AspNetUsers> Listar()
        {
            var cont = new List<AspNetUsers>();
            try
            {
                using (var context = new ImiContext())
                {
                    //cont = context.AspNetUsers.ToList();
                    var con = context.AspNetUserRoles.Where(x => x.RoleId == "2a4e987a-3cdb-4f33-a358-81c38ec002d6")
                                                     .Select(x => x.UserId)
                                                     .ToList();

                    cont = context.AspNetUsers.Where(x => con.Contains(x.Id)).ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return cont;

        }




        public List<AspNetUsers> Todo()
        {
            var mes = new List<AspNetUsers>();
            try
            {
                using (var context = new ImiContext())
                {
                    mes = context.AspNetUsers.ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return mes;

        }


        public List<AspNetUsers> ListarUser()
        {
            var cont = new List<AspNetUsers>();
            try
            {
                using (var context = new ImiContext())
                {
                    //cont = context.AspNetUsers.ToList();
                    var con = context.AspNetUserRoles.Where(x => x.RoleId == "2a4e987a-3cdb-4f33-a358-81c38ec002d6")
                                                     .Select(x => x.UserId)
                                                     .ToList();

                    cont = context.AspNetUsers.Where(x => con.Contains(x.Id)).ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return cont;

        }



        public AspNetUsers Obtener(string id)
        {
            var cont = new AspNetUsers();
            try
            {
                using (var ctx = new ImiContext())
                {
                    cont = ctx.AspNetUsers.Include("negocio")
                                            .Where(x => x.Id == id)
                                            .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return cont;
        }


    }
}
