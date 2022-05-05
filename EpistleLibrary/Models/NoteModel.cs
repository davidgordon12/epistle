namespace EpistleLibrary.Models
{
    public class NoteModel
    {
        public string Title { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Content { get; set; }

        public int UserId { get; set; }
        public UserModel User { get; set; }
    }
}
