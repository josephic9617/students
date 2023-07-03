using System.Threading.Tasks;
using welcome_api.Dtos;

namespace welcome_api.Interfaces
{
    public interface IStudentRepo
    {
        Task<PagedResult<StudentResponseDto>> GetStudents(int page, int limit, string name, int course);
        Task<int> CreateStudent(StudentRequestDto studentDto);
        Task<PagedResult<NoteResponseDto>> GetNotesByStudent(int page, int limit, int studentid);
    }
}
