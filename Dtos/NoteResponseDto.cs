using System;
using welcome_api.Models;

namespace welcome_api.Dtos
{
    public class NoteResponseDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int StudentId { get; set; }
    }
}