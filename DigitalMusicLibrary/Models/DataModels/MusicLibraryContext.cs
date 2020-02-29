using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Models.DataModels
{
    public class MusicLibraryContext : DbContext
    {
        public static readonly string ConString = ConfigurationManager.ConnectionStrings["MusicLibraryCon"].Name;
        public MusicLibraryContext() : base($"{ConString}")
        {

            Database.SetInitializer<MusicLibraryContext>(new MusicLibraryDbInitializer());
        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<MusicDetail> MusicDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
           .Property(column => column.RoleID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<UserRole>()
           .Property(column => column.UserID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<MusicDetail>()
           .Property(column => column.MusicID)
           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}