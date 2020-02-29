using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Models.DataModels
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [StringLength(150)]
        [Required]
        public string RoleName { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}