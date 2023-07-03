using welcome_api.Models;

namespace welcome_api.Dtos
{
    public class StudentNoteDto
    {
        public string Text { get; set; }
        public int StudentId { get; set; }

        public Note ToModel()
        {
            return new Note { Text = Text, StudentId = StudentId };
        }
    }
}
