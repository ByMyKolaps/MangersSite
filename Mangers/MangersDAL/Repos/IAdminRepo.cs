using MangersDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MangersDAL.Repos
{
    public interface IAdminRepo
    {
        public Task AddManga(Manga art);
        public Task AddChapter(Chapter chapter);
    }
}
