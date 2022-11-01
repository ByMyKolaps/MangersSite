using MangersWebApi.Helpers;
using MangersWebApi.Models;
using MangersWebApi.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MangersWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        protected WebApiContext _context;
        private readonly ILogger<WeatherForecastController> _logger;
        private IWebHostEnvironment _environment = null;

        protected WeatherForecastController()
        {
            _context = (WebApiContext)Services.CollectionServices.GetService(typeof(WebApiContext));
        }

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWebHostEnvironment environment, WebApiContext context)
        {
            _context = context;
            _logger = logger;
            _environment = environment;
        }

        [HttpGet]
        public List<Page> Get(string chapterNumber, int mangaId)
        {
            var response = _context.Pages.Where(p => p.ChapterNumber.ToString() == chapterNumber && p.MangaId == mangaId).ToList();
            return response;
        }

        [HttpPost]
        public string Post([FromForm]PagesUploadViewModel pages)
        {
            Page page = new Page();
            page.ChapterNumber = Convert.ToInt32(pages.ChapterNumber);
            page.PageNumber = Convert.ToInt32(pages.PageNumber);
            page.MangaId = Convert.ToInt32(pages.MangaId);
            string photoPath;
            if (pages.Page != null)
            {
                photoPath = _environment.AddFile(pages.Page, "/img/");
                page.ImageUrl = photoPath;
            }
            _context.Pages.Add(page);
            _context.SaveChanges();
            return "Ok";
        }
    }
}
