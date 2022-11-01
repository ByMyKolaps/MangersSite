using MangersDAL.Models;
using MangersDAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MangersDAL.ReposRealization
{
    public class ProfileRepo : Repo, IProfileRepo
    {
        public List<int> GetAllUserBookmarks(string name)
        {
            List<int> bookmarks = _context.Bookmarks.Where(b => b.UserName == name).Select(b => b.MangaId).ToList();
            return bookmarks;
        }
        public List<int> GetTypedUserBookmarks(string name, BookmarkType bookmarkType)
        {
            List<int> bookmarks = _context.Bookmarks.Where(b => b.UserName == name && b.BookmarkType == bookmarkType).Select(b => b.MangaId).ToList();
            return bookmarks;
        }
        public List<Manga> GetMangas(List<int> ids)
        {
            List<Manga> mangas = new List<Manga>();
            foreach(var id in ids)
            {
                Manga manga = _context.Mangas.FirstOrDefault(m => m.MangaId == id);
                mangas.Add(manga);
            }
            return mangas;
        }

        public void SaveUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
