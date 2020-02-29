using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Models.DataModels
{
    public class MusicDetail
    {
        [Key]        
        public int MusicID { get; set; }

        [Required]
        [StringLength(500)]
        public string TitleName { get; set; }

        [Required]
        [StringLength(500)]
        public string AlbuName { get; set; }

        [Required]
        [StringLength(500)]
        public string ComposerName { get; set; }

        [Required]
        public byte[] File { get; set; }

        [Required]
        [StringLength(500)]
        public string FileName { get; set; }

        [Required]
        [StringLength(500)]
        public string ArtistName { get; set; }

        public DateTime ReleasedDate { get; set; }

    }
}