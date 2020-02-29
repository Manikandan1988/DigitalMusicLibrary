using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName Required")]
        [StringLength(200)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}