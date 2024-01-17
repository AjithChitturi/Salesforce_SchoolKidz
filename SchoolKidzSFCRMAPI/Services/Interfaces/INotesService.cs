using Microsoft.AspNetCore.Mvc;
using SchoolkidzModels.Inputmodels;
using SchoolkidzModels.OutputModels;


namespace SchoolKidzSFCRMAPI.Services.Interfaces
{
    public interface INotesService
    {
        
        public Task<List<NotesOutModel>> GetNotes();
        public Task<List<NotesOutModel>> GetNotesByParentId(string ParentId);

        public Task<List<NotesOutModel>> GetAttachments();
        public Task<List<NotesOutModel>> GetAttachmentsByLinkedEntityId(string LinkedEntityId);

        public Task<IActionResult> DownloadNote(string id, string endPoint);
        public Task<IActionResult> DownloadAttachments(string id, Controllers.NotesController controllerInstance);
    }
}
