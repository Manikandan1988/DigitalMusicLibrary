using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Models.ViewModels
{
    public class AddMusicViewModel
    {        

        [Required(ErrorMessage = "Enter Title Name")]
        [Display(Name = "Title Name")]
        [StringLength(500)]
        public string TitleName { get; set; }

        [Required(ErrorMessage = "Enter Album Name")]
        [Display(Name = "Album Name")]
        [StringLength(500)]
        public string AlbuName { get; set; }

        [Required(ErrorMessage = "Enter Composer Name")]
        [Display(Name = "Composer Name")]
        [StringLength(500)]
        public string ComposerName { get; set; }
      
        [Required(ErrorMessage = "Enter Artist Name")]
        [Display(Name = "Artist Name")]
        [StringLength(500)]
        public string ArtistName { get; set; }

        
        [Display(Name = "UploadFile")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }

        [Required(ErrorMessage = "Release Date is Required")]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleasedDate { get; set; }
    }
}