using System;
using System.Collections.Generic;

namespace Dal_Repository.Model
{
    public partial class Lecturer
    {
        public Lecturer()
        {
            Courses = new HashSet<Course>();
        }

        public int LecturerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
