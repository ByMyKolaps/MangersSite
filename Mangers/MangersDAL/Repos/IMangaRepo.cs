using MangersDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MangersDAL.Repos
{
    public interface IMangaRepo
    {
        public Task<Manga> GetMangaById(int mangaId);
        public Task<Manga> GetMangaByIdWithChapters(int mangaId);
        public List<Chapter> GetMangaChapters(int mangaId);
        public string GetMangaName(int mangaId);
        public void PostComment(int mangaId, string content, int estimation, string owner);
        public void AddBookmark(Bookmark bookmark);
        public bool IsPremium(int mangaId);
    }
}
