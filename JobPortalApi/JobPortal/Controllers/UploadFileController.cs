using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JobPortalLib.DAL;
using JobPortalLib.DAL.Interfaces;
using JobPortalLib.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        IRecruiterDAL _recruiterDAL;
        ILogEntry _logEntry;
        private static readonly Random _random = new Random();
        public UploadFileController(ILogEntry logEntry)
        {
            _logEntry = logEntry;
        }
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".pdf", ".word" };        
        [HttpPost]
        public HttpResponseMessage UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                string filepath = @"D:\Tupakula\JobPortal\JobPortal\";
                string folderName = "UploadFile";               
                string newPath = Path.Combine(filepath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent("Uploaded Successfully")
                };                
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;

            }
            catch (System.Exception ex)
            {
                var resp = new HttpResponseMessage()
                {
                    Content = new StringContent("Failed")
                };
                resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return resp;
            }
        }
    }
}