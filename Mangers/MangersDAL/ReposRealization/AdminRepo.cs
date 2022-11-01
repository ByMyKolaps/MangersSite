using MangersDAL.Models;
using MangersDAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MangersDAL.ReposRealization
{
    public class AdminRepo : Repo, IAdminRepo
    {
        public async Task AddManga(Manga manga)
        {
            await _context.Mangas.AddAsync(manga);
            await _context.SaveChangesAsync();
        }

        public async Task AddChapter(Chapter chapter)
        {
            await _context.Chapters.AddAsync(chapter);
            await _context.SaveChangesAsync();
        }

    }
}
