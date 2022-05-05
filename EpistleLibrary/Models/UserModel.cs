namespace EpistleLibrary.Models
{
    public class UserModel
    {
        public int Id { get; set; } 
        public string Username { get; set; }
        public int Password { get; set; }
        public List<NoteModel>? Notes { get; set; }
    }
}