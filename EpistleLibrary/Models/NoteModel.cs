using System.ComponentModel.DataAnnotations;

namespace EpistleLibrary.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Content { get; set; }

        public UserModel User { get; set; }
        public BookshelfModel Bookshelf { get; set; } = new BookshelfModel { Title = "" };
    }
}
