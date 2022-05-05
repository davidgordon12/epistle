using System.ComponentModel.DataAnnotations;

namespace EpistleLibrary.Models
{
    public class UserModel
    {
        [Key]
        public string Username { get; set; }
        public int Password { get; set; }
        public List<NoteModel>? Notes { get; set; }
    }
}