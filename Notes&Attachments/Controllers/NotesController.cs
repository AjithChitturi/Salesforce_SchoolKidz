using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Notes_Attachments.Models;
using System.Reflection.PortableExecutable;
using System;
using System.Text;
using System.Collections;

namespace Notes_Attachments.Controllers
{
    public class NotesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7006/api");
        private readonly HttpClient _client;

        public NotesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }


        [HttpGet]

        public async Task<IActionResult> Note()
        {
            List<NotesViewModel> Notelist = new List<NotesViewModel>();
            HttpResponseMessage response =  _client.GetAsync(_client.BaseAddress + "/Notes/GetNotes").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Notelist = JsonConvert.DeserializeObject<List<NotesViewModel>>(data);
            }

            return View(Notelist);
        }

 
        [HttpGet]
        public IActionResult DownloadNote(string id)
        {
            string apiUrl = _client.BaseAddress + "/Notes/DownloadNote/Download/" + id;
            
            using (HttpClient client = new HttpClient())
            
            {
                HttpResponseMessage response =  client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)

                {

                    if (response.Content.Headers.ContentType != null)

                    {
                        var stream = response.Content.ReadAsStreamAsync().Result;

                        if (response.Content.Headers.ContentDisposition?.FileName != null)

                        {
                            var fileResult = new FileStreamResult(stream, response.Content.Headers.ContentType.MediaType)
                            {
                                FileDownloadName = response.Content.Headers.ContentDisposition.FileName.Trim('"')
                            };

                            return fileResult;

                        }
                    }
                }
            }
            return NotFound();
        }




        [HttpGet]

        public IActionResult Attachments()
        {
            List<NotesViewModel> Attachmentlist = new List<NotesViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Notes/GetAttachments").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Attachmentlist = JsonConvert.DeserializeObject<List<NotesViewModel>>(data);
            }

            return View(Attachmentlist);
        }


        [HttpGet]
        public IActionResult DownloadAttachments(string id)
        {
            string apiUrl = _client.BaseAddress + "/Notes/DownloadAttachments/Download/" + id;

            using (HttpClient client = new HttpClient())

            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)

                {

                    if (response.Content.Headers.ContentType != null)

                    {
                        var stream = response.Content.ReadAsStreamAsync().Result;

                        if (response.Content.Headers.ContentDisposition?.FileName != null)

                        {
                            var fileResult = new FileStreamResult(stream, response.Content.Headers.ContentType.MediaType)
                            {
                                FileDownloadName = response.Content.Headers.ContentDisposition.FileName.Trim('"')
                            };

                            return fileResult;

                        }
                    }
                }
            }
            return NotFound();
        }
    }
}
