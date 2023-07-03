using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using welcome_api.Dtos;
using welcome_api.Interfaces;
using welcome_api.Models;

namespace welcome_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly WelcomeDbContext _context;
        private readonly IStudentRepo _studentRepo;

        public StudentsController(WelcomeDbContext context, IStudentRepo studentRepo)
        {
            _context = context;
            _studentRepo = studentRepo;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] StudentRequestDto studentDto)
        {
            int studentId = await _studentRepo.CreateStudent(studentDto);
            if (studentId > 0)
            {
                return Ok(studentId);
            }
            return BadRequest();
        }

       

        [HttpGet("list")]
        public async Task<IActionResult> GetList([FromQuery] int page = 1, [FromQuery] int limit = 10, [FromQuery] string name = null, [FromQuery] int course = 0)
        {
            PagedResult<StudentResponseDto> students = await _studentRepo.GetStudents(page, limit, name, course);
            return Ok(students);
        }
        
        [HttpGet("studentNotes")]
        public async Task<IActionResult> GetStudentNotes([FromQuery] int studentId, [FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var notes = await _studentRepo.GetNotesByStudent(page, limit, studentId);
            return Ok(notes);
        }

        [HttpPost("addNote")]
        public async Task<ActionResult> AddNote([FromBody] StudentNoteDto noteDto)
        {
            var note = noteDto.ToModel();
            if (note == null)
            {
                return BadRequest("Maglumat Ýalňyş girizdiňiz!");
            }
            _context.Notes.Add(note);
            int count = await _context.SaveChangesAsync();
            if (count > 0)
            {
                return Ok(note.Id);
            }
            return BadRequest();
        }

        [HttpPut("editNote")]
        public async Task<IActionResult> EditNote([FromBody] NoteRequestDto noteDto)
        {
            var note = _context.Notes.FirstOrDefault(f => f.Id == noteDto.Id);
            if (note == null)
            {
                return NotFound($"{noteDto.Id} belgili bellik tapylmady!");
            }
            note.Text = noteDto.Text;
            int count = await _context.SaveChangesAsync();
            return Ok(count);
        }

        [HttpDelete("deleteStudentsNotes/{studentid}")]
        public async Task<IActionResult> DeleteStudentsNotes(int studentid)
        {
            int count = await _context.Notes.Where(f => f.StudentId == studentid).ExecuteDeleteAsync();
            return Ok(count);
        }

        [HttpGet("{studentid}/notes")]
        public async Task<IActionResult> GetNotesByStudent([FromRoute] int studentid)
        {
            var notesQuery = _context.Notes
                .Include(f => f.Student).ThenInclude(s => s.Topar)
                .Where(f => f.StudentId == studentid)
                .AsNoTracking()
                .Select(f => StudentNoteResponseDto.FromModel(f));
            var notes = await notesQuery.ToListAsync();
            return Ok(notes);
        }


    }
}
