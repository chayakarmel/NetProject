using System;
using System.Collections.Generic;

namespace Dal_Repository.Model
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string? IconPath { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
