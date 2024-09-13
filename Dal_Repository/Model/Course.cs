using System;
using System.Collections.Generic;

namespace Dal_Repository.Model
{
    public partial class Course
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

        public virtual Category Category { get; set; } = null!;
        public virtual Lecturer Lecturer { get; set; } = null!;
        public virtual LearningMode Mode { get; set; } = null!;
    }
}
