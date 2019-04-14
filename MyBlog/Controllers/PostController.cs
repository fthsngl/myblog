using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.DataBase;
using MyBlog.Models.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MyBlog.Controllers
{
    public class PostController : Controller
    {
        BlogContext _db;
        WriteModel _model;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PostController(BlogContext db, WriteModel model, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _model = model;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateWrite()
        {
            return View(_model);
        }
        [HttpPost]
        public IActionResult CreateWrite(WriteModel wm)
        {
            
            _db.Entry(wm.Write).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _db.SaveChanges();
            return RedirectToAction("CreateWrite", "Post");
        }
        [HttpPost("FileUploader")]
        public async Task<IActionResult> CreateImage(List<IFormFile> files)
        {
            var theFile = HttpContext.Request.Form.Files.GetFile("file");
            string webRootPath = _hostingEnvironment.WebRootPath;
            var fileRoute = Path.Combine(webRootPath, "uploads");
            var mimeType = HttpContext.Request.Form.Files.GetFile("file");
            string extension = Path.GetExtension(theFile.FileName);
            string name = Guid.NewGuid().ToString().Substring(0, 8) + extension;
            string link = Path.Combine(fileRoute, name);


            string[] imageMimetypes = { "image/gif", "image/jpeg", "image/pjpeg", "image/x-png", "image/png", "image/svg+xml" };
            string[] imageExt = { ".gif", ".jpeg", ".jpg", ".png", ".svg", ".blob" };
            try
            {
                if (Array.IndexOf(imageMimetypes, mimeType) >= 0 && (Array.IndexOf(imageExt, extension) >= 0))
                {
                    Stream stream;
                    stream = new MemoryStream();
                    theFile.CopyTo(stream);
                    stream.Position = 0;
                    string serverPath = link;

                    using (FileStream writerFileStream = System.IO.File.Create(serverPath))
                    {
                        await stream.CopyToAsync(writerFileStream);
                        writerFileStream.Dispose();
                    }
                    Hashtable imageUrl = new Hashtable();
                    imageUrl.Add("wwwroot/image", "image" + name);
                    return Json(imageUrl);
                }
                throw new ArgumentException("Hatalı oldu");
            }
            catch (ArgumentException ex)
            {

                return Json(ex.Message);
            }

        }
    }
}