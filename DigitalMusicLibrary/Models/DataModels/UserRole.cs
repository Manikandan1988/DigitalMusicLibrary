using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Models.DataModels
{
    public class UserRole
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(200)]
        [Required]
        public string UserName { get; set; }

        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        //Foreign key for Role
        public int RoleID { get; set; }
        public Role Role { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}