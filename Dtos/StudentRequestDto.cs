using System.Collections.Generic;
using System;
using welcome_api.Models;

namespace welcome_api.Dtos
{
    public class StudentRequestDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Course { get; set; }

        public Student ToModel()
        {
            return new Student { Name = Name, Lastname = Lastname, Course = Course };
        }
    }
}
