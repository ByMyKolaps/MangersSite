using MangersDAL.Models;
using MangersDAL.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangersDAL.ReposRealization
{
    public class MangaRepo : Repo, IMangaRepo
    {
        public void AddBookmark(Bookmark bookmark)
        {
            _context.Bookmarks.Add(bookmark);
            _context.SaveChanges();
        }

        public async Task<Manga> GetMangaById(int mangaId)
        {
            var result = await _context.Mangas
                .Include(m => m.Comments)
                    .ThenInclude(m => m.Owner)
                .FirstOrDefaultAsync(m => m.MangaId == mangaId);
            return result;
        }

        public async Task<Manga> GetMangaByIdWithChapters(int mangaId)
        {
            return await _context.Mangas.Include(m => m.Chapters).FirstOrDefaultAsync(m => m.MangaId == mangaId);
        }

        public List<Chapter> GetMangaChapters(int mangaId)
        {
            return _context.Chapters.Where(c => c.MangaId == mangaId).ToList();
        }

        public string GetMangaName(int mangaId)
        {
            return _context.Mangas.FindAsync(mangaId).Result.Name;
        }

        public void PostComment(int mangaId, string content, int estimation, string owner)
        {
            User _owner = _context.Users.FirstOrDefault(u => u.UserName == owner);
            Comments comments = new Comments
            {
                OwnerId = _owner.Id,
                MangaId = mangaId,
                Content = content,
                Estimation = estimation
            };
            Manga manga = _context.Mangas
                .Include(m => m.Comments)
                .FirstOrDefault(m => m.MangaId == mangaId);
            double sumOfRate = manga.Comments.Sum(m => m.Estimation) + estimation;
            manga.Rating = Math.Round(sumOfRate/(manga.Comments.Count + 1), 1); 
            _context.Comments.Add(comments);
            _context.SaveChanges();
        }

        public bool IsPremium(int mangaId)
        {
            return _context.Mangas.FirstOrDefault(m => m.MangaId == mangaId).IsPremium;
        }
    }
}
