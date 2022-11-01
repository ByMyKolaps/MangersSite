using MangersDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangersDAL.Repos
{
    public interface IProfileRepo
    {
        public List<int> GetAllUserBookmarks(string name);
        public List<int> GetTypedUserBookmarks(string name, BookmarkType bookmarkType);
        public List<Manga> GetMangas(List<int> ids);
        public void SaveUser(User user);

        
    }
}
