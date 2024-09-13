using System;
using System.Collections.Generic;

namespace Dal_Repository.Model
{
    public partial class LearningMode
    {
        public LearningMode()
        {
            Courses = new HashSet<Course>();
        }

        public int ModeId { get; set; }
        public string ModeName { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
