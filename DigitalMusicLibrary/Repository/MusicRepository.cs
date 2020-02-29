using DigitalMusicLibrary.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalMusicLibrary.Repository
{
    public class MusicRepository<T> : IMusicRepository<T> where T : class
    {

        private MusicLibraryContext _context = null;
        private DbSet<T> table = null;
        public MusicRepository()
        {
            this._context = new MusicLibraryContext();
            table = _context.Set<T>();
        }
        public MusicRepository(MusicLibraryContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }


    }
}