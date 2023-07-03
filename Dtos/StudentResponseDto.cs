using System.Collections.Generic;
using System;
using welcome_api.Models;

namespace welcome_api.Dtos
{
    public class StudentResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Course { get; set; }
        public Topar Topar { get; set; }

        public static StudentResponseDto FromModel(Student model)
        {
            return new StudentResponseDto { 
                Id = model.Id,
                Name = model.Name, 
                Lastname = model.Lastname, 
                Course = model.Course,
                Topar = model.Topar,
            };
        }
    }
}
