using MangersDAL.Models;
using MangersDAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MangersDAL.ReposRealization
{
    public class MangaMockRepo : IMangaRepo
    {
        public void AddBookmark(Bookmark bookmark)
        {
            throw new NotImplementedException();
        }

        public async Task<Manga> GetMangaById(int mangaId)
        {
            List<Manga> mangas = new List<Manga>()
            {
                new Manga() { MangaId = 1, Name = "Наруто", IsPremium = false, Description = "Крутое аниме" },
                new Manga() { MangaId = 2, Name = "Наруто", IsPremium = false, Description = "Крутое аниме" },
                new Manga() { MangaId = 3, Name = "Наруто", IsPremium = false, Description = "Крутое аниме" }
            };
            return mangas.Find(m => m.MangaId == mangaId);
        }

        public Task<Manga> GetMangaByIdWithChapters(int mangaId)
        {
            throw new NotImplementedException();
        }

        public List<Chapter> GetMangaChapters(int mangaId)
        {
            throw new NotImplementedException();
        }

        public string GetMangaName(int mangaId)
        {
            throw new NotImplementedException();
        }

        public bool IsPremium(int mangaId)
        {
            List<Manga> mangas = new List<Manga>()
            {
                new Manga() { MangaId = 1, Name = "Наруто", IsPremium = false, Description = "Крутое аниме" },
                new Manga() { MangaId = 2, Name = "Наруто", IsPremium = true, Description = "Крутое аниме" },
                new Manga() { MangaId = 3, Name = "Наруто", IsPremium = false, Description = "Крутое аниме" }
            };
            return mangas.Find(m => m.MangaId == mangaId).IsPremium;
        }

        public void PostComment(int mangaId, string content, int estimation, string owner)
        {
            throw new NotImplementedException();
        }
    }
}
