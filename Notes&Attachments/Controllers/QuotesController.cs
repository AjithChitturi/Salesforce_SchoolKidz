using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Notes_Attachments.Models;

namespace Notes_Attachments.Controllers
{
    public class QuotesController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7006/api");
        private readonly HttpClient _client;

        public QuotesController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }


        [HttpGet]

        public async Task<IActionResult> Quote()
        {
            List<QuotesViewModel> Quotelist = new List<QuotesViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/QuoteRequest/GetQuotes").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Quotelist = JsonConvert.DeserializeObject<List<QuotesViewModel>>(data);
            }

            return View(Quotelist);
        }

        
        [HttpGet]

        public async Task<IActionResult> QuoteAttachments(string id)
        {
            List<NotesViewModel> Attachmentlist = new List<NotesViewModel>();

            // Assuming _client is an instance of HttpClient
            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/Notes/GetAttachmentsByLinkedEntityId?LinkedEntityId=" + id);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                Attachmentlist = JsonConvert.DeserializeObject<List<NotesViewModel>>(data);
            }

            return View(Attachmentlist);
        }



        [HttpGet]

        public async Task<IActionResult> QuoteNote(string id)
        {
            List<NotesViewModel> Notelist = new List<NotesViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Notes/GetNotesByParentId?ParentId=" + id).Result;

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
