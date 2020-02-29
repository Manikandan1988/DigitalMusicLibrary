using DigitalMusicLibrary.Filters;
using DigitalMusicLibrary.Models.DataModels;
using DigitalMusicLibrary.Models.ViewModels;
using DigitalMusicLibrary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalMusicLibrary.Controllers
{
    [UserRoleValidateFilter]

    public class ViewMusicDetailController : Controller
    {

        private IMusicRepository<MusicDetail> repository = null;
        public ViewMusicDetailController()
        {
            this.repository = new MusicRepository<MusicDetail>();
        }
        public ViewMusicDetailController(IMusicRepository<MusicDetail> repository)
        {
            this.repository = repository;
        }

        public ActionResult ViewMusicDetails()
        {
            var musicList = repository.GetAll().Select(row => new DisplayMusicDetailViewModel
            {
                AlbuName = row.AlbuName,
                ArtistName = row.ArtistName,
                ComposerName = row.ComposerName,
                FileName = row.FileName,
                ReleasedDate = row.ReleasedDate,
                TitleName = row.TitleName

            }).ToList();
            return View(musicList);
        }
    }
}