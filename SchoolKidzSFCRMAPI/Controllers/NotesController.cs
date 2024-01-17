using Microsoft.AspNetCore.Mvc;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;
using SchoolKidzSFCRMAPI.Services.Interfaces;


namespace SchoolKidzSFCRMAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        INotesService _notesService;
        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        [HttpGet]
        public async Task<List<NotesOutModel>> GetNotes()
        {
            return await _notesService.GetNotes();
        }

        [HttpGet]
        public async Task<List<NotesOutModel>> GetNotesByParentId(string ParentId)
        {
            return await _notesService.GetNotesByParentId(ParentId);
        }


        [HttpGet]
        public async Task<List<NotesOutModel>> GetAttachments()
        {
            return await _notesService.GetAttachments();
        }

        [HttpGet]

        public async Task<List<NotesOutModel>> GetAttachmentsByLinkedEntityId(string LinkedEntityId)
        {
            return await _notesService.GetAttachmentsByLinkedEntityId(LinkedEntityId);
        }




        [HttpGet("Download/{id}")]
        public async Task<IActionResult> DownloadNote(string id)
        {
            return await _notesService.DownloadNote(id, "/services/data/v58.0/query?q=");
        }

        [HttpGet("Download/{id}")]
        public async Task<IActionResult> DownloadAttachments(string id)
        {
            var controllerInstance = this;
            return await _notesService.DownloadAttachments(id , controllerInstance);
        }
    }
}
