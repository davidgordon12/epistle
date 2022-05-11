using System.ComponentModel.DataAnnotations;

namespace EpistleLibrary.Models
{
    public class BookshelfModel
    {
        [Key]
        public string Title { get; set; }
        public List<NoteModel> Notes { get; set; }
        public UserModel User { get; set; }
    }
}
