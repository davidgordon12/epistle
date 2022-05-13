using System.ComponentModel.DataAnnotations;

namespace EpistleLibrary.Models
{
    public class BookshelfModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public UserModel? User { get; set; }
    }
}
