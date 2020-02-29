using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Models.ViewModels
{
    public class DisplayMusicDetailViewModel
    {

        [Display(Name = "Title Name")]
        public string TitleName { get; set; }

        [Display(Name = "Album Name")]
        public string AlbuName { get; set; }

        [Display(Name = "Composer Name")]
        public string ComposerName { get; set; }
        
        [Display(Name = "Artist Name")]       
        public string ArtistName { get; set; }

        [Display(Name = "Composition File Name")]
        public string FileName { get; set; }

        [Display(Name = "Release Date")]        
        public DateTime ReleasedDate { get; set; }
    }
}