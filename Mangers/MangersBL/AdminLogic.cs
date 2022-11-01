using MangersDAL.Models;
using MangersDAL.Repos;
using MangersDAL.ReposRealization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MangersBL
{
    public class AdminLogic
    {
        public static IAdminRepo AdminRepo = new AdminRepo();
        public static async Task AddManga(Manga manga)
        {
            await AdminRepo.AddManga(manga);
        }
        public static async Task AddChapter(Chapter chapter)
        {
            chapter.DateOfCreation = DateTime.Now;
            await AdminRepo.AddChapter(chapter);
        }
        public static bool AddPages(IFormFile pages, int chapterNumber, int pageNumber, int mangaId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var form = new MultipartFormDataContent())
                {
                    using (var fs = pages.OpenReadStream())
                    {
                        using (var streamContent = new StreamContent(fs))
                        {
                            using (var fileContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result))
                            {
                                form.Add(fileContent, "Page", Path.GetFileName(pages.FileName));
                                form.Add(new StringContent(chapterNumber.ToString()), "ChapterNumber");
                                form.Add(new StringContent(pageNumber.ToString()), "PageNumber");
                                form.Add(new StringContent(mangaId.ToString()), "MangaId");
                                HttpResponseMessage response = httpClient.PostAsync("https://localhost:44341/WeatherForecast", form).Result;
                                
                                fileContent.Dispose();
                                streamContent.Dispose();
                                fs.Dispose();
                                form.Dispose();
                                httpClient.Dispose();
                                return response.IsSuccessStatusCode;
                            }
                        }
                    }
                }
            }
        }
    }
}
