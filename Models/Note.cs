using System;

namespace welcome_api.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int StudentId { get; set; }
        public DateTime Crdate { get; set; }
        public int CrUserid { get; set; }
        public Student Student { get; set; }
    }
}
