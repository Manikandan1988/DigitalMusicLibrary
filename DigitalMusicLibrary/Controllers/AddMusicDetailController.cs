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
    [AdminRoleValidateFilter]
    public class AddMusicDetailController : Controller
    {
        private IMusicRepository<MusicDetail> repository = null;
        public AddMusicDetailController()
        {
            this.repository = new MusicRepository<MusicDetail>();
        }
        public AddMusicDetailController(IMusicRepository<MusicDetail> repository)
        {
            this.repository = repository;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadMusicDetais()
        {
            return View(new AddMusicViewModel());
        }

        [HttpPost]
        public ActionResult UploadMusicDetais(AddMusicViewModel viewModel, HttpPostedFileBase uploadFile)
        {
            if (!string.IsNullOrEmpty(uploadFile?.FileName))
            {
                var musicDetail = new MusicDetail
                {
                    AlbuName = viewModel.AlbuName,
                    ArtistName = viewModel.ArtistName,
                    ComposerName = viewModel.ComposerName,
                    FileName = uploadFile.FileName,
                    ReleasedDate = viewModel.ReleasedDate,
                    TitleName = viewModel.TitleName
                };

                using (var reader = new System.IO.BinaryReader(uploadFile.InputStream))
                {
                    musicDetail.File = reader.ReadBytes(uploadFile.ContentLength);
                }

                repository.Insert(musicDetail);
                repository.Save();

            }
            else
            {
                ModelState.AddModelError("", "Please upload a file");
                return View(viewModel);
            }
            return View("Index");
        }
    }
}