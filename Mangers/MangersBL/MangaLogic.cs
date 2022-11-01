using MangersDAL.Models;
using MangersDAL.Repos;
using MangersDAL.ReposRealization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MangersBL
{
    public class MangaLogic
    {
        public static IMangaRepo MangaRepo = new MangaRepo();
        public static void SetMockRepo()
        {
            MangaRepo = new MangaMockRepo();
        }
        public static async Task<Manga> GetMangaById(int mangaId)
        {
            return await MangaRepo.GetMangaById(mangaId);
        }

        public static async Task<Manga> GetMangaByIdWithChapters(int mangaId)
        {
            return await MangaRepo.GetMangaByIdWithChapters(mangaId);
        }

        public static List<Chapter> GetMangaChapters(int mangaId)
        {
            return MangaRepo.GetMangaChapters(mangaId);
        }

        public static async Task<List<Page>> GetChapterPages(int chapterNumber, int mangaId)
        {
            string model;
            WebRequest request = WebRequest.Create($"https://localhost:44341/WeatherForecast?chapterNumber={chapterNumber}&mangaId={mangaId}");
            request.Method = "Get";
            WebResponse response = await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    model = reader.ReadToEnd();
                }
            }
            var parsed = JsonConvert.DeserializeObject<List<Page>>(model);

            return parsed;
        }

        public static string GetMangaName(int mangaId)
        {
            return MangaRepo.GetMangaName(mangaId);
        }

        public static void PostComment(int mangaId, string content, int estimation, string owner)
        {
            MangaRepo.PostComment(mangaId, content, estimation, owner);
        }

        public static void AddBookmark(string bookmarkType, string user, int mangaId)
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

            Bookmark bookmark = new Bookmark()
            {
                UserName = user,
                BookmarkType = _bookmarkType,
                MangaId = mangaId
            };
            MangaRepo.AddBookmark(bookmark);
        }

        public static bool IsPremium(int mangaId)
        {
            return MangaRepo.IsPremium(mangaId);
        }
    }
}
