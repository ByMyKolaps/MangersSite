using MangersDAL.Models;
using MangersDAL.Repos;
using MangersDAL.ReposRealization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangersBL
{
    public class ProfileLogic
    {
        public static IProfileRepo ProfileRepo = new ProfileRepo();
        public static List<Manga> GetBookmarks(string name, string bookmarkType)
        {
            if(bookmarkType != null)
            {
                BookmarkType _bookmarkType = new BookmarkType();
                if (bookmarkType == "Читаю")
                    _bookmarkType = BookmarkType.Читаю;
                if (bookmarkType == "Прочитаю")
                    _bookmarkType = BookmarkType.Прочитаю;
                if (bookmarkType == "Прочитано")
                    _bookmarkType = BookmarkType.Прочитано;
                if (bookmarkType == "Отложено")
                    _bookmarkType = BookmarkType.Отложено;
                if (bookmarkType == "Брошено")
                    _bookmarkType = BookmarkType.Брошено;
                List<int> userBookmarks = ProfileRepo.GetTypedUserBookmarks(name, _bookmarkType);
                List<Manga> mangas = ProfileRepo.GetMangas(userBookmarks);
                return mangas;
            }
            else
            {
                List<int> userBookmarks = ProfileRepo.GetAllUserBookmarks(name);
                List<Manga> mangas = ProfileRepo.GetMangas(userBookmarks);
                return mangas;
            }
        }

        public static void SaveUser(User user)
        {
            ProfileRepo.SaveUser(user);
        }

    }
}
