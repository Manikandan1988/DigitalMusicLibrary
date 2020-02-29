using DigitalMusicLibrary.Models.DataModels;
using DigitalMusicLibrary.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Repository
{
    public interface ILoginRepository
    {
        UserRole Login(UserRole userDetails);
    }
    public class LoginRepository : ILoginRepository
    {
        private MusicLibraryContext _context = null;

        public LoginRepository()
        {
            this._context = new MusicLibraryContext();

        }

        public UserRole Login(UserRole userDetails)
        {
            return _context.UserRoles.FirstOrDefault(row => row.UserName == userDetails.UserName && row.Password == userDetails.Password);
        }
    }
}