using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.AuthenticationLayer.Services;
using SchoolKidzSFCRMAPI.Controllers;
using SchoolKidzSFCRMAPI.ModelsNew;
using SchoolKidzSFCRMAPI.Services.Interfaces;
using System.Net.Http.Headers;
using SchoolKidzSFCRMAPI.Services.RequestLayer;
using System.Text;
using Microsoft.Extensions.Hosting;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System;
using SchoolkidzModels.Inputmodels;

namespace SchoolKidzSFCRMAPI.Services
{
    public class NotesService : INotesService
    {
        private readonly IRequestService _requestService;
        private readonly IAuthService _authService;

        public NotesService(IRequestService requestService, IAuthService authService)
        {
            _requestService = requestService;
            _authService = authService;
        }

        public async Task<List<NotesOutModel>> GetNotes()
        {
            var query = "SELECT Id, Title, Body FROM Note";
            var jsonResponse = await _requestService.Get(query, false, "/services/data/v58.0/query?q=");

            var recordObject = JsonConvert.DeserializeObject<NotesListModel>(jsonResponse);

            var notesList = new List<NotesOutModel>();

            foreach (var record in recordObject.records)
            {
                var note = new NotesOutModel
                {
                    recordId = record.Id,
                    fileNmae = record.Title,
                    documentBody = record.Body
                };

                notesList.Add(note);
            }

            return notesList;
        }

        public async Task<List<NotesOutModel>> GetNotesByParentId(string ParentId)
        {
            var query = $"SELECT Id, Title, Body FROM Note WHERE ParentId = '{ParentId}'";
            var jsonResponse = await _requestService.Get(query, false, "/services/data/v58.0/query?q=");

            var recordObject = JsonConvert.DeserializeObject<NotesListModel>(jsonResponse);

            var notesList = new List<NotesOutModel>();

            foreach (var record in recordObject.records)
            {
                var note = new NotesOutModel
                {
                    recordId = record.Id,
                    fileNmae = record.Title,
                    documentBody = record.Body
                };

                notesList.Add(note);
            }

            return notesList;
        }

        public async Task<List<NotesOutModel>> GetAttachments()
        {
            var query = "SELECT Id, Title,  FileExtension FROM ContentVersion";
            var ret = await _requestService.Get(query, false, "/services/data/v58.0/query?q=");

            var recordObject = JsonConvert.DeserializeObject<NotesListModel>(ret);

            var attachmentsList = new List<NotesOutModel>();

            foreach (var record in recordObject.records)
            {
                var note = new NotesOutModel
                {
                    recordId = record.Id,
                    fileNmae = record.Title,
                    type = record.FileExtension
                };

                attachmentsList.Add(note);
            }

            return attachmentsList;
        }

        public async Task<List<NotesOutModel>> GetAttachmentsByLinkedEntityId(string LinkedEntityId)
        {
            var query = $"SELECT ContentDocument.Id, ContentDocument.Title, LinkedEntityId, ContentDocument.LatestPublishedVersionId FROM ContentDocumentLink WHERE LinkedEntityId = '{LinkedEntityId}'";

            var jsonResponse = await _requestService.Get(query, false, "/services/data/v58.0/query?q=");

            var recordObject = JsonConvert.DeserializeObject<NotesListModel>(jsonResponse);

            var attachmentsList = new List<NotesOutModel>();

            foreach (var record in recordObject.records)
            {
                var note = new NotesOutModel
                {
                    recordId = record.ContentDocument?.LatestPublishedVersionId,
                    fileNmae = record.ContentDocument?.Title,
                };

                attachmentsList.Add(note);
            }

            return attachmentsList;
        }

        public async Task<IActionResult> DownloadNote(string id, string endpoint)
        {
            string query = $"SELECT Id, Title, Body FROM Note WHERE Id = '{id}'";
            string jsonResponse = await _requestService.Get(query, false, endpoint);

            dynamic noteData = JsonConvert.DeserializeObject(jsonResponse);
            string title = noteData.records[0].Title.ToString();
            string content = noteData.records[0].Body.ToString();

            byte[] byteArray = Encoding.UTF8.GetBytes(content);

            var fileResult = new FileContentResult(byteArray, "text/plain");
            fileResult.FileDownloadName = $"{title}.txt";

            return fileResult;
        }

        public async Task<IActionResult> DownloadAttachments(string id, NotesController controller)
        {

            var _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _authService.getToken());

            var fileDownload = $"{_authService.getInstanceUrl()}/sfc/servlet.shepherd/version/download/{id}";


            var response = await _httpClient.GetAsync(fileDownload);

            var bytes = await response.Content.ReadAsByteArrayAsync();
            var contenttype = response.Content.Headers.ContentType.MediaType;

            string title = "example_file";

            var fileExtension = GetFileExtension(contenttype);
            var fileName = $"{title}.{fileExtension}";

            return controller.File(bytes, contenttype, fileName);
        }

        private string GetFileExtension(string? type)
        {
            var extension = type?.Split('/').LastOrDefault();
            return extension ?? "dat";
        }


    }
}



