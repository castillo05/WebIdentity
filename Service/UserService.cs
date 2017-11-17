using Model;
using Model.Custom;
using Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public class UserService
    {
        public IEnumerable<UserGrid> GetAll()
        {
            var result = new List<UserGrid>();

            using (var ctx = new ApplicationDbContext())
            {
                var roles = ctx.ApplicationUserRoles.ToList();
                result = (
                         from ua in ctx.ApplicationUsers
                         from aur in ctx.ApplicationUserRoles.Where(x => x.UserId == ua.Id).DefaultIfEmpty()
                         from ar in ctx.ApplicationRoles.Where(x => x.Id == aur.RoleId && x.Enable).DefaultIfEmpty()
                         select new UserGrid
                         {
                             Id = ua.Id,
                             Name = ua.Name,
                             Email= ua.Email,
                             LastName = ua.LastName,
                             Role = ar.Name
                         }).ToList();
            }

            return result;
        }


        public ApplicationUser Get(string id)
        {
            var result = new ApplicationUser();

            using (var ctx = new ApplicationDbContext())
            {
                result = ctx.ApplicationUsers.Where(x => x.Id == id).Single();
            }

            return result;
        }

        public void Update(ApplicationUser model)
        {
            var result = new List<ApplicationUser>();

            using (var ctx = new ApplicationDbContext())
            {
                var originalEntity = ctx.ApplicationUsers.Where(x => x.Id == model.Id).Single();
                originalEntity.Name = model.Name;
                originalEntity.LastName = model.LastName;
                ctx.Entry(originalEntity).State = EntityState.Modified;
                ctx.SaveChanges();
            }

            
        }


    }
}
