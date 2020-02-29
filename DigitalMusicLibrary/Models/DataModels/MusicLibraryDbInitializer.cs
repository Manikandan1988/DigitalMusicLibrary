using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Models.DataModels
{
    public class MusicLibraryDbInitializer : CreateDatabaseIfNotExists<MusicLibraryContext>
    {

        protected override void Seed(MusicLibraryContext context)
        {
            IList<Role> rolesList = new List<Role>();

            rolesList.Add(new Role() { RoleName = "Admin", IsActive = true });
            rolesList.Add(new Role() { RoleName = "User", IsActive = true });
            context.Roles.AddRange(rolesList);
            IList<UserRole> userList = new List<UserRole>
            {
                new UserRole
            {
                RoleID = 1,
                UserName = "Admin",
                Password = "Admin",
                CreatedDate = DateTime.Now

            },
                new UserRole
            {
                RoleID = 2,
                UserName = "User",
                Password = "User",
                CreatedDate = DateTime.Now

            }
        };
            context.UserRoles.AddRange(userList);

            context.SaveChanges();
            base.Seed(context);
        }

    }

}