using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace welcome_api.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Course { get; set; }
        public List<Note> Notes { get; set; }
        public DateTime Crdate { get; set; }
        public int CrUserid { get; set; }
        public Topar Topar { get; set; }
        public int? ToparId { get; set; }
    }
}
