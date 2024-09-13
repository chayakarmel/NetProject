using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public int CategoryId { get; set; }
        public int NumberOfLessons { get; set; }
        public DateTime StartDate { get; set; }
        public string? Syllabus { get; set; }
        public int ModeId { get; set; }
        public int LecturerId { get; set; }
        public string? ImagePath { get; set; }
    }
}
