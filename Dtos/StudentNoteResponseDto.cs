using welcome_api.Models;

namespace welcome_api.Dtos
{
    public class StudentNoteResponseDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public StudentResponseDto Student { get; set; }

        public static StudentNoteResponseDto FromModel(Note model)
        {
            return new StudentNoteResponseDto
            {
                Id = model.Id,
                Text = model.Text, 
                Student = model.Student is not null ? StudentResponseDto.FromModel(model.Student) : null
            };
        }
    }
}
