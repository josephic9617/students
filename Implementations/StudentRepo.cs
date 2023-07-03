using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using welcome_api.Dtos;
using welcome_api.Interfaces;
using welcome_api.Models;

namespace welcome_api.Implementations
{
    public class StudentRepo : IStudentRepo
    {
        private readonly WelcomeDbContext _context;
        public StudentRepo(WelcomeDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<StudentResponseDto>> GetStudents(int page, int limit, string name, int course)
        {
            var studentQuery = _context.Students
                            .Select(f => new StudentResponseDto()
                            {
                                Id = f.Id,
                                Name = f.Name,
                                Course = f.Course,
                                Lastname = f.Lastname,
                            }
                            );
            if (name != null)
            {
                studentQuery = studentQuery.Where(f => f.Name.Contains(name));
            }

            if (course != 0)
            {
                studentQuery = studentQuery.Where(f => f.Course == course);

            }
            var students = await studentQuery.GetPaged(page, limit);
            return students;
        }

        public async Task<int> CreateStudent(StudentRequestDto studentDto)
        {
            var student = studentDto.ToModel();
            if (student == null)
            {
                return 0;
            }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student.Id;
        }

        public async Task<PagedResult<NoteResponseDto>> GetNotesByStudent(int page, int limit, int studentid)
        {
            var query = _context.Notes.Where(f => f.StudentId == studentid).AsNoTracking()
                .Select(f => new NoteResponseDto
                {
                    StudentId = f.StudentId,
                    Id = f.Id,
                    Text = f.Text,
                });
            return await query.GetPaged(page, limit);
        }
    }
}
