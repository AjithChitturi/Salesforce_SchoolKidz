using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Notes_Attachments.Models
{
    public class NotesViewModel
    {

        public string recordId { get; set; }

        [DisplayName("Note Title")]
        public string fileNmae { get; set; }
        public string documentBody { get; set; }
        public string type { get; set; }

        public string subject { get; set; }
    }
}
