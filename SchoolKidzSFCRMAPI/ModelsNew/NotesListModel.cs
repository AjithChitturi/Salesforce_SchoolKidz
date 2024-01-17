using System.Collections.Generic;

namespace SchoolKidzSFCRMAPI.ModelsNew
{
    public class NotesListModel
    {
        public List<RecordObject> records { get; set; }
    }

    public class RecordObject
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string FileExtension { get; set; }

        public ContentDocument ContentDocument { get; set; }
    }

    public class ContentDocument
    {
        public string LatestPublishedVersionId { get; set; }
        public string Title { get; set; }
    }
}
